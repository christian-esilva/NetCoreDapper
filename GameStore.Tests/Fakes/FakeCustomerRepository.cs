using GameStore.Domain.StoreContext.Entities;
using GameStore.Domain.StoreContext.Queries;
using GameStore.Domain.StoreContext.Respositories;

namespace GameStore.Tests.Fakes
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

        public CustomerOrdersCountResult GetCustomerOrdersCount(string document)
        {
            throw new System.NotImplementedException();
        }

        public void Save(Customer customer)
        {
            
        }
    }
}