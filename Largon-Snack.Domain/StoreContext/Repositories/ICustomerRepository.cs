using Largon_Snack.Domain.StoreContext.Entities;

namespace Largon_Snack.Domain.StoreContext.Repositories
{
    public interface ICustomerRepository
    {
        bool CheckDocument(string document);
        bool CheckEmail(string email);
        void Save(Customer customer);
    }
    
}