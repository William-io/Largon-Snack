using Largon_Snack.Domain.StoreContext.Entities;
using Largon_Snack.Domain.StoreContext.Repositories;

namespace Largon_Snack.Test.Fakes
{

    public class FakeCustomerRepository : ICustomerRepository
    {
        public bool CheckDocument(string document)
        {
            return false;
        }

        public bool CheckEmail(string email)
        {
            return false;
        }

        public void Save(Customer customer)
        {          
        }
    }
}