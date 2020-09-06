using MyShoppingCart.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyShoppingCart
{
    public interface IShoppingCart
    {
        #region Properties
        IList<Product> Items { get; }
        #endregion 

        #region Methods
        void AddToCart(Product product);
        decimal CheckOut();
        #endregion

    }
}
