using GameStore.Domain.StoreContext.Entities;
using GameStore.Domain.StoreContext.Queries;

namespace GameStore.Domain.StoreContext.Respositories
{
    public interface ICustomerRepository
    {
        bool CheckDocument(string document);
        bool CheckEmail(string email);
        void Save(Customer customer);
        CustomerOrdersCountResult GetCustomerOrdersCount(string document);
    }
}