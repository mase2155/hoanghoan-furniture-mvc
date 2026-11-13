using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace hoanghoan_furniture_devmaster.Models.DBModel;

public partial class HoangHoanFurniteDevMasterContext : DbContext
{
    public HoangHoanFurniteDevMasterContext()
    {
    }

    public HoangHoanFurniteDevMasterContext(DbContextOptions<HoangHoanFurniteDevMasterContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AdminUser> AdminUsers { get; set; }

    public virtual DbSet<AuditLog> AuditLogs { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Contact> Contacts { get; set; }

    public virtual DbSet<ContactRequest> ContactRequests { get; set; }

    public virtual DbSet<ContentBlock> ContentBlocks { get; set; }
    public virtual DbSet<CustomerUser> CustomerUsers { get; set; }
    public virtual DbSet<EmailQueue> EmailQueues { get; set; }

    public virtual DbSet<Extension> Extensions { get; set; }

    public virtual DbSet<Material> Materials { get; set; }

    public virtual DbSet<News> News { get; set; }

    public virtual DbSet<Partner> Partners { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<SiteSetting> SiteSettings { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=.;Database=HoangHoanFurnite_DevMaster;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AdminUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ADMIN_US__3214EC2739901ACE");

            entity.ToTable("AdminUser");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Account)
                .HasMaxLength(200)
                .HasColumnName("ACCOUNT");
            entity.Property(e => e.Avatar)
                .HasMaxLength(200)
                .HasColumnName("AVATAR");
            entity.Property(e => e.Email)
                .HasMaxLength(500)
                .HasColumnName("EMAIL");
            entity.Property(e => e.IdPhongBan).HasColumnName("ID_PHONG_BAN");
            entity.Property(e => e.IsAdmin).HasColumnName("IS_ADMIN");
            entity.Property(e => e.IsDelete).HasColumnName("IS_DELETE");
            entity.Property(e => e.MaNhanSu).HasColumnName("MA_NHAN_SU");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("NAME");
            entity.Property(e => e.NgayCapNhat)
                .HasColumnType("datetime")
                .HasColumnName("NGAY_CAP_NHAT");
            entity.Property(e => e.NgayTao)
                .HasColumnType("datetime")
                .HasColumnName("NGAY_TAO");
            entity.Property(e => e.NguoiCapNhat)
                .HasMaxLength(200)
                .HasColumnName("NGUOI_CAP_NHAT");
            entity.Property(e => e.NguoiTao)
                .HasMaxLength(200)
                .HasColumnName("NGUOI_TAO");
            entity.Property(e => e.Password)
                .HasMaxLength(200)
                .HasColumnName("PASSWORD");
            entity.Property(e => e.Phone)
                .HasMaxLength(30)
                .HasColumnName("PHONE");
            entity.Property(e => e.Salt)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("SALT");
            entity.Property(e => e.SessionToken)
                .HasMaxLength(500)
                .HasColumnName("SESSION_TOKEN");
            entity.Property(e => e.TrangThai).HasColumnName("TRANG_THAI");
        });

        modelBuilder.Entity<AuditLog>(entity =>
        {
            entity.ToTable("AuditLog");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Action).HasMaxLength(255);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("CREATED_DATE");
            entity.Property(e => e.IpAddress).HasMaxLength(50);
            entity.Property(e => e.TableName).HasMaxLength(100);
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PRODUCT___A88186B13985BFD1");

            entity.ToTable("Category");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AdminCreated)
                .HasMaxLength(255)
                .HasColumnName("ADMIN_CREATED");
            entity.Property(e => e.AdminUpdated)
                .HasMaxLength(255)
                .HasColumnName("ADMIN_UPDATED");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("CREATED_DATE");
            entity.Property(e => e.Icon)
                .HasMaxLength(200)
                .HasColumnName("ICON");
            entity.Property(e => e.Isdelete).HasColumnName("ISDELETE");
            entity.Property(e => e.MateTitle)
                .HasMaxLength(500)
                .HasColumnName("MATE_TITLE");
            entity.Property(e => e.MetaDescription)
                .HasMaxLength(500)
                .HasColumnName("META_DESCRIPTION");
            entity.Property(e => e.MetaKeyword)
                .HasMaxLength(500)
                .HasColumnName("META_KEYWORD");
            entity.Property(e => e.Notes)
                .HasColumnType("ntext")
                .HasColumnName("NOTES");
            entity.Property(e => e.Orders).HasColumnName("ORDERS");
            entity.Property(e => e.Parentid).HasColumnName("PARENTID");
            entity.Property(e => e.Slug)
                .HasMaxLength(500)
                .HasColumnName("SLUG");
            entity.Property(e => e.Status).HasColumnName("STATUS");
            entity.Property(e => e.Title)
                .HasMaxLength(200)
                .HasColumnName("TITLE");
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("datetime")
                .HasColumnName("UPDATED_DATE");
        });

        modelBuilder.Entity<Contact>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_CONTACT");

            entity.ToTable("Contact");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .HasColumnName("ADDRESS");
            entity.Property(e => e.AdminCreated)
                .HasMaxLength(255)
                .HasColumnName("ADMIN_CREATED");
            entity.Property(e => e.AdminUpdated)
                .HasMaxLength(255)
                .HasColumnName("ADMIN_UPDATED");
            entity.Property(e => e.Content)
                .HasColumnType("ntext")
                .HasColumnName("CONTENT");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("CREATED_DATE");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Isdelete).HasColumnName("ISDELETE");
            entity.Property(e => e.Phone)
                .HasMaxLength(255)
                .HasColumnName("PHONE");
            entity.Property(e => e.Status).HasColumnName("STATUS");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasColumnName("TITLE");
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("datetime")
                .HasColumnName("UPDATED_DATE");
        });

        modelBuilder.Entity<ContactRequest>(entity =>
        {
            entity.ToTable("ContactRequest");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("CREATED_DATE");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.FullName).HasMaxLength(255);
            entity.Property(e => e.Isdelete)
                .HasDefaultValue(false)
                .HasColumnName("ISDELETE");
            entity.Property(e => e.Phone).HasMaxLength(50);
            entity.Property(e => e.Status).HasDefaultValue((byte)0);
            entity.Property(e => e.Subject).HasMaxLength(255);
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("datetime")
                .HasColumnName("UPDATED_DATE");
        });

        modelBuilder.Entity<ContentBlock>(entity =>
        {
            entity.ToTable("ContentBlock");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("CREATED_DATE");
            entity.Property(e => e.Image).HasMaxLength(500);
            entity.Property(e => e.Isdelete)
                .HasDefaultValue(false)
                .HasColumnName("ISDELETE");
            entity.Property(e => e.KeyName).HasMaxLength(100);
            entity.Property(e => e.Status).HasDefaultValue((byte)1);
            entity.Property(e => e.Title).HasMaxLength(255);
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("datetime")
                .HasColumnName("UPDATED_DATE");
        });

        modelBuilder.Entity<EmailQueue>(entity =>
        {
            entity.ToTable("EmailQueue");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("CREATED_DATE");
            entity.Property(e => e.RetryCount).HasDefaultValue(0);
            entity.Property(e => e.SentDate).HasColumnType("datetime");
            entity.Property(e => e.Status).HasDefaultValue((byte)0);
            entity.Property(e => e.Subject).HasMaxLength(500);
            entity.Property(e => e.ToEmail).HasMaxLength(500);
        });

        modelBuilder.Entity<Extension>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PRODUCT___EXTENSION");

            entity.ToTable("Extension");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AdminCreated)
                .HasMaxLength(255)
                .HasColumnName("ADMIN_CREATED");
            entity.Property(e => e.AdminUpdated)
                .HasMaxLength(255)
                .HasColumnName("ADMIN_UPDATED");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("CREATED_DATE");
            entity.Property(e => e.Icon)
                .HasMaxLength(200)
                .HasColumnName("ICON");
            entity.Property(e => e.Isdelete).HasColumnName("ISDELETE");
            entity.Property(e => e.MetaDescription)
                .HasMaxLength(500)
                .HasColumnName("META_DESCRIPTION");
            entity.Property(e => e.MetaKeyword)
                .HasMaxLength(500)
                .HasColumnName("META_KEYWORD");
            entity.Property(e => e.MetaTitle)
                .HasMaxLength(500)
                .HasColumnName("META_TITLE");
            entity.Property(e => e.Notes)
                .HasColumnType("ntext")
                .HasColumnName("NOTES");
            entity.Property(e => e.Orders).HasColumnName("ORDERS");
            entity.Property(e => e.Parentid).HasColumnName("PARENTID");
            entity.Property(e => e.Slug)
                .HasMaxLength(500)
                .HasColumnName("SLUG");
            entity.Property(e => e.Status).HasColumnName("STATUS");
            entity.Property(e => e.Title)
                .HasMaxLength(200)
                .HasColumnName("TITLE");
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("datetime")
                .HasColumnName("UPDATED_DATE");
        });

        modelBuilder.Entity<Material>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MATERIAL___EXTENSION");

            entity.ToTable("Material");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AdminCreated)
                .HasMaxLength(255)
                .HasColumnName("ADMIN_CREATED");
            entity.Property(e => e.AdminUpdated)
                .HasMaxLength(255)
                .HasColumnName("ADMIN_UPDATED");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("CREATED_DATE");
            entity.Property(e => e.Icon)
                .HasMaxLength(200)
                .HasColumnName("ICON");
            entity.Property(e => e.Isdelete).HasColumnName("ISDELETE");
            entity.Property(e => e.MetaDescription)
                .HasMaxLength(500)
                .HasColumnName("META_DESCRIPTION");
            entity.Property(e => e.MetaKeyword)
                .HasMaxLength(500)
                .HasColumnName("META_KEYWORD");
            entity.Property(e => e.MetaTitle)
                .HasMaxLength(500)
                .HasColumnName("META_TITLE");
            entity.Property(e => e.Notes)
                .HasColumnType("ntext")
                .HasColumnName("NOTES");
            entity.Property(e => e.Orders).HasColumnName("ORDERS");
            entity.Property(e => e.Parentid).HasColumnName("PARENTID");
            entity.Property(e => e.Slug)
                .HasMaxLength(500)
                .HasColumnName("SLUG");
            entity.Property(e => e.Status).HasColumnName("STATUS");
            entity.Property(e => e.Title)
                .HasMaxLength(200)
                .HasColumnName("TITLE");
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("datetime")
                .HasColumnName("UPDATED_DATE");
        });

        modelBuilder.Entity<News>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__NEWS__3214EC27E639B94D");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AdminCreated)
                .HasMaxLength(255)
                .HasColumnName("ADMIN_CREATED");
            entity.Property(e => e.AdminUpdated)
                .HasMaxLength(255)
                .HasColumnName("ADMIN_UPDATED");
            entity.Property(e => e.Code)
                .HasMaxLength(10)
                .HasColumnName("CODE");
            entity.Property(e => e.Content)
                .HasColumnType("ntext")
                .HasColumnName("CONTENT");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("CREATED_DATE");
            entity.Property(e => e.Description).HasColumnName("DESCRIPTION");
            entity.Property(e => e.Image).HasColumnName("IMAGE");
            entity.Property(e => e.Isdelete).HasColumnName("ISDELETE");
            entity.Property(e => e.Likes).HasColumnName("LIKES");
            entity.Property(e => e.MainKeyword)
                .HasMaxLength(500)
                .HasColumnName("MAIN_KEYWORD");
            entity.Property(e => e.MetaDescription)
                .HasMaxLength(500)
                .HasColumnName("META_DESCRIPTION");
            entity.Property(e => e.MetaKeyword)
                .HasMaxLength(500)
                .HasColumnName("META_KEYWORD");
            entity.Property(e => e.MetaTitle)
                .HasMaxLength(500)
                .HasColumnName("META_TITLE");
            entity.Property(e => e.Slug)
                .HasMaxLength(500)
                .HasColumnName("SLUG");
            entity.Property(e => e.Star).HasColumnName("STAR");
            entity.Property(e => e.Status).HasColumnName("STATUS");
            entity.Property(e => e.Title)
                .HasMaxLength(200)
                .HasColumnName("TITLE");
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("datetime")
                .HasColumnName("UPDATED_DATE");
            entity.Property(e => e.Views).HasColumnName("VIEWS");
        });

        modelBuilder.Entity<Partner>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PARTNER__3214EC27F1B87F08");

            entity.ToTable("Partner");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AdminCreated)
                .HasMaxLength(255)
                .HasColumnName("ADMIN_CREATED");
            entity.Property(e => e.AdminUpdated)
                .HasMaxLength(255)
                .HasColumnName("ADMIN_UPDATED");
            entity.Property(e => e.Content).HasColumnName("CONTENT");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("CREATED_DATE");
            entity.Property(e => e.Isdelete).HasColumnName("ISDELETE");
            entity.Property(e => e.Logo)
                .HasMaxLength(255)
                .HasColumnName("LOGO");
            entity.Property(e => e.Orders).HasColumnName("ORDERS");
            entity.Property(e => e.Status).HasColumnName("STATUS");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasColumnName("TITLE");
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("datetime")
                .HasColumnName("UPDATED_DATE");
            entity.Property(e => e.Url)
                .HasMaxLength(255)
                .HasColumnName("URL");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Products__3214EC2739AA3707");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.Name).HasMaxLength(250);
            entity.Property(e => e.NewPrice).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.RateByStars)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(3, 2)");
            entity.Property(e => e.Urlimage)
                .HasMaxLength(500)
                .HasColumnName("URLImage");
        });

        modelBuilder.Entity<SiteSetting>(entity =>
        {
            entity.ToTable("SiteSetting");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.SettingKey).HasMaxLength(100);
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("datetime")
                .HasColumnName("UPDATED_DATE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
