using Largon_Snack.Domain.StoreContext.Services;

namespace Largon_Snack.Test.Fakes
{

    public class FakeEmailServices : IEmailService
    {
        public void Send(string to, string from, string subject, string body)
        {
            
        }
    }
}