using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;

namespace GameStore.Tests
{
    [TestClass]
    public class CreateCustomerCommandTests
    {
        public void ShouldValidateWhenCommandIsValid()
        {
            var command = new CreateCustomerCommand();
            command.FirstName = "Christian";
            command.LastName = "Silva";
            command.Document = "28659170377";
            command.Email = "christian.eds@hotmail.com";
            command.Phone = "11999999997";

            Assert.AreEqual(true, command.Valid());
        }
    }
}