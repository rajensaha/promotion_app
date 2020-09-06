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
            Assert.That(_shoppingCart.Items.Count,Is.EqualTo(1));
        }

       
        [Test]
        public void test_checkout()
        {            
            var ex = Assert.Throws<NotImplementedException>(() => _shoppingCart.CheckOut());
            Assert.That(ex.Message, Is.EqualTo("The method or operation is not implemented."));
        }



    }
}
