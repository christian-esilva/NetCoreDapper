using System;

namespace GameStore.Domain.StoreContext.Queries
{
    public class ListCustomerQueryResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
    }
}