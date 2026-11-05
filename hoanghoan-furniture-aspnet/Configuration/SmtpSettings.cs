namespace hoanghoan_furniture_aspnet.Configuration
{
    public class SmtpSettings
    {
        public string server { get; set; }
        public int port { get; set; }
        public string senderName { get; set; }
        public string senderEmail { get; set; }
        public string password { get; set; }
        public bool enableSSL { get; set; } = true;
    }
}
