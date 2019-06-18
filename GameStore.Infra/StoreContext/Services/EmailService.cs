using System;
using GameStore.Domain.StoreContext.Services;

namespace GameStore.Infra.StoreContext.Services
{
    public class EmailService : IEmailService
    {
        public void Send(string to, string from, string subject, string body)
        {
            throw new NotImplementedException();
        }
    }
}