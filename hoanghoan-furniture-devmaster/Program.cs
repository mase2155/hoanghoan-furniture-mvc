using hoanghoan_furniture_devmaster.Configuration;
using hoanghoan_furniture_devmaster.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;
using hoanghoan_furniture_devmaster.Services;
using hoanghoan_furniture_devmaster.Tools;

namespace hoanghoan_furniture_devmaster
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            if (args.Contains("--smtp-diagnostic", StringComparer.OrdinalIgnoreCase))
            {
                Environment.Exit(SmtpDiagnosticRunner.RunAsync(builder.Configuration).GetAwaiter().GetResult());
                return;
            }

            Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(builder.Configuration)
            .Enrich.FromLogContext()
            .CreateLogger();

            builder.Host.UseSerilog();

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();
            
            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            
            // SEO , SMTP 
            builder.Services.Configure<SiteSettings>(
                builder.Configuration.GetSection("SiteSettings"));
            builder.Services.Configure<SeoSettings>(
                builder.Configuration.GetSection("SeoSettings"));
            builder.Services.Configure<SmtpSettings>(
                builder.Configuration.GetSection("SmtpSettings"));
            builder.Services.AddTransient <IEmailService,SmtpEmailService>();


            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();

            builder.Services.AddDistributedMemoryCache();
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromHours(8);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
                options.Cookie.Name = ".DinhHung.Session";
            });

            var app = builder.Build();

            app.UseSerilogRequestLogging();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseSession();
            

            app.MapControllerRoute(
                name: "areas",
                pattern:"{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();
            try
            {
                Log.Information("Ứng dụng đang khởi động...");
                app.Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Ứng dụng bị lỗi khi khởi động!");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
}
