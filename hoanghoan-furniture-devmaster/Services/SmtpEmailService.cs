using hoanghoan_furniture_devmaster.Configuration;
using MailKit;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;

namespace hoanghoan_furniture_devmaster.Services
{
    public class SmtpEmailService : IEmailService
    {
        private readonly SmtpSettings _smtp;

        public SmtpEmailService(IOptions<SmtpSettings> options)
        {
            _smtp = options.Value;
        }

        public async Task SendAsync(string toEmail, string subject, string htmlBody, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(_smtp.Host))
                throw new InvalidOperationException("SmtpSettings:Host chưa cấu hình.");
            if (string.IsNullOrWhiteSpace(_smtp.SenderEmail))
                throw new InvalidOperationException("SmtpSettings:SenderEmail chưa cấu hình.");
            if (string.IsNullOrWhiteSpace(_smtp.Password))
                throw new InvalidOperationException("SmtpSettings:Password trống — set User Secrets.");

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(_smtp.SenderName ?? _smtp.SenderEmail, _smtp.SenderEmail));
            message.To.Add(MailboxAddress.Parse(toEmail));
            message.Subject = subject;
            message.Body = new TextPart("html") { Text = htmlBody };

            using var client = new SmtpClient();
            var socketOptions = _smtp.Port == 465
                ? SecureSocketOptions.SslOnConnect
                : SecureSocketOptions.StartTls;

            await client.ConnectAsync(_smtp.Host, _smtp.Port, socketOptions, cancellationToken);
            await client.AuthenticateAsync(_smtp.SenderEmail, _smtp.Password, cancellationToken);
            await client.SendAsync(FormatOptions.Default, new SendRequest(message) , cancellationToken);
            await client.DisconnectAsync(true, cancellationToken);
        }
    }
}