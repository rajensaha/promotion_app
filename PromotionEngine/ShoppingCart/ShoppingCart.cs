using System;
using System.Collections.Generic;
using System.Text;

namespace MyShoppingCart
{
    public class ShoppingCart : IShoppingCart
    {
        private readonly IList<IProduct> _items;
        public ShoppingCart()
        {
            _items = new List<IProduct>();
        }
        public IList<IProduct> Items => _items;

        public void AddToCart(IProduct product)
        {
            _items.Add(product);
        }

        public decimal Checkout()
        {
            throw new NotImplementedException();
        }
    }
}
