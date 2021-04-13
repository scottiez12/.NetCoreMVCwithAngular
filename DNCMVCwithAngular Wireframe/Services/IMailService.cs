namespace DNCMVCwithAngular_Wireframe.Services
{
    public interface IMailService
    {
        void SendMessage(string to, string subject, string body);
    }
}