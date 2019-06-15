using GameStore.Domain.StoreContext.Entities;
using GameStore.Domain.StoreContext.Enums;
using GameStore.Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameStore.Tests.Entities
{
    [TestClass]
    public class OrderTests
    {
        private Product _mouse;
        private Product _keyboard;
        private Product _monitor;
        private Product _chair;
        private Customer _customer;
        private Order _order;

        public OrderTests()
        {
            var name = new Name("Christian", "Silva");
            var document = new Document("58390265060");
            var email = new Email("christian.eds@hotmail.com");
            _customer = new Customer(name, document, email, "1199559955");
            _order = new Order(_customer);

            _mouse = new Product("Mouse G3", "Mouse gamer", "mouse.jpg", 100M, 10);
            _keyboard = new Product("Teclado G3", "Teclado gamer", "Teclado.jpg", 100M, 10);
            _chair = new Product("Cadeira G3", "Cadeira gamer", "Cadeira.jpg", 100M, 10);
            _monitor = new Product("Monitor G3", "Monitor gamer", "Monitor.jpg", 100M, 10);
        }

        //consigo criar um novo pedido
        [TestMethod]
        public void ShouldCreateOrderWhenValid()
        {
            Assert.AreEqual(true, _order.IsValid);
        }

        //ao criar um pedido o status deve ser created
        [TestMethod]
        public void StatusShouldBeCreatedWhenOrderCreate()
        {
            Assert.AreEqual(EOrderStatus.Created, _order.Status);
        }

        //ao adicionar um novo item, a quantidade de itens deve mudar
        [TestMethod]
        public void StatusReturnTwoWhenAddedTwoValidItens()
        {
            _order.AddItem(_monitor, 5);
            _order.AddItem(_mouse, 5);
            Assert.AreEqual(2, _order.Items.Count);
        }

        //ao adicionar um novo item, deve subtrair a quantidade em estoque
        [TestMethod]
        public void ShouldReturnFiveWhenAddedPurchaseFiveItem()
        {
            _order.AddItem(_mouse, 5);
            Assert.AreEqual(_mouse.QuantityOnHand, 5);
        }

        //Ao confirmar pedido, deve gerar um número
        [TestMethod]
        public void ShouldReturnANumberWhenOrderPlaced()
        {
            _order.Place();
            Assert.AreNotEqual("", _order.Number);
        }

        //ao pagar um pedido, o status deve ser PAGO
        [TestMethod]
        public void ShouldReturnPaidWhenOrderPaid()
        {
            _order.Pay();
            Assert.AreEqual(EOrderStatus.Paid, _order.Status);
        }

        //dados 10 produtos, devem haver duas entregas
        [TestMethod]
        public void ShouldTwoShippingsWhenPurchaseTenProducts()
        {
            _order.AddItem(_monitor, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);

            _order.Ship();
            Assert.AreEqual(2, _order.Deliveries.Count);
        }

        //ao cancelar um pedido, o status deve ser cancelado
        [TestMethod]
        public void StatusShouldCanceledWhenOrderCanceled()
        {
            _order.Cancel();
            Assert.AreEqual(EOrderStatus.Canceled, _order.Status);
        }

        //ao cancelar um pedido, deve cancelar as entregas
        [TestMethod]
        public void ShouldCancelShippingsWhenOrderCanceled()
        {
            _order.AddItem(_monitor, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);

            _order.Cancel();
            foreach (var x in _order.Deliveries)
            {
                Assert.AreEqual(EDeliveryStatus.Canceled, x.Status);
            }

        }
    }
}
