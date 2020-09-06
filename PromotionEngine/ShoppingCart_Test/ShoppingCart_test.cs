using System;
using Moq;
using MyShoppingCart;
using MyShoppingCart.Model;
using NUnit.Framework;

namespace ShoppingCart_Test
{
    [TestFixture]
    public class ShoppingCart_test
    {
        private IShoppingCart _shoppingCart;
        [SetUp]
        public void initial_setup()
        {
            _shoppingCart = new ShoppingCart();
        }

        [Test]
        public void mock_test_add_to_cart()
        {
            Mock<Product> mockProduct = new Mock<Product>();
            _shoppingCart.AddToCart(mockProduct.Object);
            Assert.That(_shoppingCart.Items.Count, Is.EqualTo(1));
        }


        [Test]
        [TestCase("A", 50)]
        [TestCase("B", 30)]
        [TestCase("C", 20)]
        [TestCase("D", 15)]
        public void test_for_each_item_cost(string sku, decimal pricePerUnit)
        {
            _shoppingCart.AddToCart(new Product() { Sku = sku, Unitprice = pricePerUnit });
            Assert.That(_shoppingCart.CheckOut(), Is.EqualTo(pricePerUnit));
        }




    }
}
