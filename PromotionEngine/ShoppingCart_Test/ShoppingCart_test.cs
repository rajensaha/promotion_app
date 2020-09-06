using System;
using Moq;
using MyShoppingCart;
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
        public void test_add_to_cart()
        {
            Mock<IProduct> mockProduct = new Mock<IProduct>();
            var ex = Assert.Throws<NotImplementedException>(() => _shoppingCart.AddToCart(mockProduct.Object));
            Assert.That(ex.Message, Is.EqualTo("The method or operation is not implemented."));
        }
        [Test]
        public void test_checkout()
        {            
            var ex = Assert.Throws<NotImplementedException>(() => _shoppingCart.Checkout());
            Assert.That(ex.Message, Is.EqualTo("The method or operation is not implemented."));
        }

    }
}
