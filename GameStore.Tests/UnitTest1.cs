using GameStore.Domain.StoreContext.Entities;
using GameStore.Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameStore.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var name = new Name("Christian", "Silva");
            var document = new Document("12345678911");
            var email = new Email("christian@silva.com");
            var c = new Customer(name, document, email, "55554444");

            var mouse = new Product("Mouse", "Gamer", "image.jpg", 59.90M, 10);
            var monitor = new Product("Monitor", "LG", "image.jpg", 800.90M, 10);
            var mousePad = new Product("MousePad", "Metal gear", "image.jpg", 29.90M, 10);
            var teclado = new Product("Teclado", "Razer", "image.jpg", 130.90M, 10);

            var order = new Order(c);
            //order.AddItem(new OrderItem(mouse, 4));
            //order.AddItem(new OrderItem(monitor, 6));
            //order.AddItem(new OrderItem(mousePad, 4));
            //order.AddItem(new OrderItem(teclado, 6));

            order.Place();

            order.Pay();

            order.Ship();

            order.Cancel();

        }
    }
}
