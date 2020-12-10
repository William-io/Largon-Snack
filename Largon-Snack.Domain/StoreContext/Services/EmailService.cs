namespace Largon_Snack.Domain.StoreContext.Services
{
    public interface IEmailService
    {    
        void Send(string to, string from, string subject, string body);

    }

}