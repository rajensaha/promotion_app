using System;
using System.Collections.Generic;
using System.Text;

namespace MyShoppingCart
{
    public interface IShoppingCart
    {
        void AddToCart(IProduct product);
        decimal Checkout();
        IList<IProduct> Items { get; }

    }
}
