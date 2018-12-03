namespace cancer_isp.Services.Interfaces
{
    public interface ISmtpService
    {
        void SendPasswordReminder(string email);
    }
}