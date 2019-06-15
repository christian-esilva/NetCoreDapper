using GameStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using GameStore.Domain.StoreContext.Handlers;
using GameStore.Tests.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameStore.Tests.Handlers
{
    public class CustomerHandlerTests
    {
        [TestMethod]
        public void ShouldRegisterCustomerWhenCommandIsValid()
        {
            var command = new CreateCustomerCommand();
            command.FirstName = "Christian";
            command.LastName = "Silva";
            command.Document = "28659170377";
            command.Email = "christian.eds@hotmail.com";
            command.Phone = "11999999997";

            var handler = new CustomerHandler(new FakeCustomerRepository(), new FakeEmailService());

            var result = handler.Handle(command);

            Assert.AreNotEqual(null, result);
            Assert.AreEqual(0, handler.IsValid);
        }
    }
}