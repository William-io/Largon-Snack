using Largon_Snack.Domain.StoreContext.Entities;
using Largon_Snack.Domain.StoreContext.Enums;
using Largon_Snack.Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Largon_Snack.Test.Entities
{
    [TestClass]
    public class OrderTests
    {
        private Customer _customer;
        private Order _order;
        private Product _meatSandwich;
        private Product _bread;
        private Product _cake;
        private Product _coffee;
        public OrderTests()
        {
            var name = new Name("William", "Vilela");
            var document = new Document("02123168343");
            var email = new Email("capuletos@live.com");
            _customer = new Customer(name, document, email, "012345678910");
            _order = new Order(_customer);
            _meatSandwich = new Product("Sanduiche de Carne", "Da Casa", "Sandwich.png", 100M, 7);
            _bread = new Product("Pao", "Leite-Pan", "Bread.png", 100M, 20);
            _cake = new Product("Bolo", "Bolo & Bolo", "Cake.png", 100M, 10);
            _coffee = new Product("Cafe pingado", "Pilao", "Coffee.png", 100M, 10);

        }
        //Consigo criar um pedido
        [TestMethod]
        public void ShouldCreateOrderWhenValid()
        {
            Assert.AreEqual(true, _order.IsValid);
        }
        //Ao criar o pedido,o status deve ser created
        [TestMethod]
        public void StatusShouldBeCreatedWhenOrderCreated()
        {
            Assert.AreEqual(EOrderStatus.Created, _order.Status);
        }

        //Ao adicionar um novo item, a quantidade de itens deve mudar
        [TestMethod]
        public void ShouldRetunrTwoWhenAddedTwoValidItems()
        {
            _order.AddItem(_coffee, 5);
            _order.AddItem(_cake, 5);
            Assert.AreEqual(2, _order.Items.Count);
        }
        //Ao adicionar um novo item, deve subtrair a quantidade do produto
        [TestMethod]
        public void ShouldRetunrFiveWhenAddedPurchasedFiveItem()
        {
            _order.AddItem(_cake, 5);
            Assert.AreEqual(_cake.QuantityOnHand, 5);
        }
        //Ao confirmar pedido, deve gerar um numero
        [TestMethod]
        public void ShouldReturnANumberWhenOrderPlaced()
        {
            _order.Place();
            Assert.AreNotEqual("", _order.Number);
        }

        //Ao pagar o pedido, o status deve ser PAGO
        [TestMethod]
        public void ShouldReturnPaidWhenOrderPaid()
        {
            _order.Pay();
            Assert.AreEqual(EOrderStatus.Paid, _order.Status);
        }

        //Dados mais 10 produtos, devem haver duas entregas.D
        [TestMethod]
        public void ShouldTwoShippingsWhenPurchasedTenProducts()
        {
            _order.AddItem(_cake, 1);
            _order.AddItem(_cake, 1);
            _order.AddItem(_cake, 1);
            _order.AddItem(_cake, 1);
            _order.AddItem(_cake, 1);
            _order.AddItem(_cake, 1);
            _order.AddItem(_cake, 1);
            _order.AddItem(_cake, 1);
            _order.AddItem(_cake, 1);
            _order.AddItem(_cake, 1);

            _order.Ship();
            Assert.AreEqual(2, _order.Deliveries.Count);
        }

        //Ao cancelar o pedido, o status deve ser cancelado
        [TestMethod]
        public void StatusShouldBeCanceledWhenORderCanceled()
        {
            _order.Cancel();
            Assert.AreEqual(EOrderStatus.Canceled, _order.Status);
        }

        //Ao cancelar o pedido, deve cancelar as entregas
        [TestMethod]
        public void ShouldCancelShippingWhenOrderCanceled()
        {
            _order.AddItem(_cake, 1);
            _order.AddItem(_cake, 1);
            _order.AddItem(_cake, 1);
            _order.AddItem(_cake, 1);
            _order.AddItem(_cake, 1);
            _order.AddItem(_cake, 1);
            _order.AddItem(_cake, 1);
            _order.AddItem(_cake, 1);
            _order.AddItem(_cake, 1);
            _order.AddItem(_cake, 1);

            _order.Ship();
            _order.Cancel();
            foreach (var x in _order.Deliveries)
            {
                Assert.AreEqual(EDeliveryStatus.Canceled,x.Status);
            }           
        }
    }
}
