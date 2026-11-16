using hoanghoan_furniture_devmaster.Configuration;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;

namespace hoanghoan_furniture_devmaster.Tools;

/// <summary>
/// Chạy một lần: dotnet run --project . -- --smtp-diagnostic
/// (thêm vào Program.cs điều kiện gọi khi args chứa --smtp-diagnostic)
/// </summary>
public static class SmtpDiagnosticRunner
{
    public static async Task<int> RunAsync(IConfiguration configuration)
    {
        var smtp = configuration.GetSection("SmtpSettings").Get<SmtpSettings>()
            ?? throw new InvalidOperationException("Không đọc được SmtpSettings");

        Console.WriteLine("=== SMTP diagnostic (không in password) ===");
        Console.WriteLine($"Host: {smtp.Host}");
        Console.WriteLine($"Port: {smtp.Port}");
        Console.WriteLine($"SenderEmail: {smtp.SenderEmail}");
        Console.WriteLine($"Password configured: {!string.IsNullOrWhiteSpace(smtp.Password)} (length={smtp.Password?.Length ?? 0})");
        Console.WriteLine($"SSL flag in config: {smtp.SSL}");
        if (smtp.Password?.Length is > 0 and < 16)
            Console.WriteLine("Gợi ý: Gmail App Password thường là 16 ký tự; mật khẩu đăng nhập web thường không dùng được SMTP.");

        var socketOptions = smtp.Port == 465
            ? SecureSocketOptions.SslOnConnect
            : SecureSocketOptions.StartTls;

        try
        {
            using var client = new SmtpClient();
            Console.WriteLine($"1) Connect {smtp.Host}:{smtp.Port} ({socketOptions})...");
            await client.ConnectAsync(smtp.Host, smtp.Port, socketOptions);
            Console.WriteLine("   -> Connect OK");

            Console.WriteLine("2) Authenticate...");
            await client.AuthenticateAsync(smtp.SenderEmail, smtp.Password);
            Console.WriteLine("   -> Authenticate OK");

            await client.DisconnectAsync(true);
            Console.WriteLine("=== Kết luận: Kết nối + xác thực SMTP thành công ===");
            return 0;
        }
        catch (Exception ex)
        {
            Console.WriteLine("=== LỖI ===");
            Console.WriteLine($"Type: {ex.GetType().Name}");
            Console.WriteLine($"Message: {ex.Message}");
            if (ex.InnerException != null)
                Console.WriteLine($"Inner: {ex.InnerException.Message}");
            if (ex.Message.Contains("535", StringComparison.OrdinalIgnoreCase)
                || ex.Message.Contains("5.7.8", StringComparison.OrdinalIgnoreCase))
                Console.WriteLine("=> Lỗi xác thực: cần Gmail App Password (2FA), không dùng pass đăng nhập web.");

            return 1;
        }
    }
}