using System;
using Moq;
using MyShoppingCart;
using MyShoppingCart.Model;
using NUnit.Framework;
using ShoppingCart.Discounts;

namespace ShoppingCart_Test
{
    [TestFixture]
    public class ShoppingCart_test
    {
        private IShoppingCart _shoppingCart;
        [SetUp]
        public void initial_setup()
        {
            _shoppingCart = new MyShoppingCart.ShoppingCart();
            _shoppingCart.AddPromotionsToCartItems(new PromotionOnProductA());
            _shoppingCart.AddPromotionsToCartItems(new PromotionOnProductB());
            _shoppingCart.AddPromotionsToCartItems(new PromotionOnProductC());
            _shoppingCart.AddPromotionsToCartItems(new PromotionOnProductD());
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

        [Test]
        public void test_3A_at_130()
        {
            _shoppingCart.AddToCart(new Product { Sku = "A", Unitprice = 50 });
            _shoppingCart.AddToCart(new Product { Sku = "A", Unitprice = 50 });
            _shoppingCart.AddToCart(new Product { Sku = "A", Unitprice = 50 });

            Assert.That(_shoppingCart.CheckOut(), Is.EqualTo(130));
        }

        [Test]
        public void test_2B_at_45()
        {
            _shoppingCart.AddToCart(new Product { Sku = "B", Unitprice = 30 });
            _shoppingCart.AddToCart(new Product { Sku = "B", Unitprice = 30 });

            Assert.That(_shoppingCart.CheckOut(), Is.EqualTo(45));
        }

        [Test]
        public void test_1C_1D_AT_30()
        {
            _shoppingCart.AddToCart(new Product { Sku = "C", Unitprice = 20 });
            _shoppingCart.AddToCart(new Product { Sku = "D", Unitprice = 15 });

            Assert.That(_shoppingCart.CheckOut(), Is.EqualTo(30));
        }

        [Test]
        public void test_2C_3D_price_after_discount()
        {
            _shoppingCart.AddToCart(new Product { Sku = "C", Unitprice = 20 });
            _shoppingCart.AddToCart(new Product { Sku = "C", Unitprice = 20 });
            _shoppingCart.AddToCart(new Product { Sku = "D", Unitprice = 15 });
            _shoppingCart.AddToCart(new Product { Sku = "D", Unitprice = 15 });
            _shoppingCart.AddToCart(new Product { Sku = "D", Unitprice = 15 });

            Assert.That(_shoppingCart.CheckOut(), Is.EqualTo(75));
        }

        [Test]
        public void test_3C_2D_price_after_discount()
        {
            _shoppingCart.AddToCart(new Product { Sku = "C", Unitprice = 20 });
            _shoppingCart.AddToCart(new Product { Sku = "C", Unitprice = 20 });
            _shoppingCart.AddToCart(new Product { Sku = "C", Unitprice = 20 });
            _shoppingCart.AddToCart(new Product { Sku = "D", Unitprice = 15 });
            _shoppingCart.AddToCart(new Product { Sku = "D", Unitprice = 15 });

            Assert.That(_shoppingCart.CheckOut(), Is.EqualTo(80));
        }

        [Test]
        public void test_scenario_A()
        {
            _shoppingCart.AddToCart(new Product { Sku = "A", Unitprice = 50 });
            _shoppingCart.AddToCart(new Product { Sku = "B", Unitprice = 30 });
            _shoppingCart.AddToCart(new Product { Sku = "C", Unitprice = 20 });
            Assert.That(_shoppingCart.CheckOut(), Is.EqualTo(100));
        }

        [Test]
        public void test_scenario_B()
        {
            _shoppingCart.AddToCart(new Product { Sku = "A", Unitprice = 50 });
            _shoppingCart.AddToCart(new Product { Sku = "A", Unitprice = 50 });
            _shoppingCart.AddToCart(new Product { Sku = "A", Unitprice = 50 });
            _shoppingCart.AddToCart(new Product { Sku = "A", Unitprice = 50 });
            _shoppingCart.AddToCart(new Product { Sku = "A", Unitprice = 50 });
            _shoppingCart.AddToCart(new Product { Sku = "B", Unitprice = 30 });
            _shoppingCart.AddToCart(new Product { Sku = "B", Unitprice = 30 });
            _shoppingCart.AddToCart(new Product { Sku = "B", Unitprice = 30 });
            _shoppingCart.AddToCart(new Product { Sku = "B", Unitprice = 30 });
            _shoppingCart.AddToCart(new Product { Sku = "B", Unitprice = 30 });
            _shoppingCart.AddToCart(new Product { Sku = "C", Unitprice = 20 });

            Assert.That(_shoppingCart.CheckOut(), Is.EqualTo(370));
        }

        [Test]
        public void test_scenario_C()
        {
            _shoppingCart.AddToCart(new Product { Sku = "A", Unitprice = 50 });
            _shoppingCart.AddToCart(new Product { Sku = "A", Unitprice = 50 });
            _shoppingCart.AddToCart(new Product { Sku = "A", Unitprice = 50 });
            _shoppingCart.AddToCart(new Product { Sku = "B", Unitprice = 30 });
            _shoppingCart.AddToCart(new Product { Sku = "B", Unitprice = 30 });
            _shoppingCart.AddToCart(new Product { Sku = "B", Unitprice = 30 });
            _shoppingCart.AddToCart(new Product { Sku = "B", Unitprice = 30 });
            _shoppingCart.AddToCart(new Product { Sku = "B", Unitprice = 30 });
            _shoppingCart.AddToCart(new Product { Sku = "C", Unitprice = 20 });
            _shoppingCart.AddToCart(new Product { Sku = "D", Unitprice = 15 });

            Assert.That(_shoppingCart.CheckOut(), Is.EqualTo(280));
        }

    }
}
