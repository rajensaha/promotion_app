using MyShoppingCart.Model;
using ShoppingCart.Discounts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyShoppingCart
{
    /// <summary>
    /// Interface contains all the required properties and methods of Shopping Cart
    /// </summary>
    public interface IShoppingCart
    {
        #region Properties

        IList<Product> Items { get; }

        #endregion 

        #region Methods

        void AddProductToCart(Product product);
        decimal CheckOut();
        void AddPromotionsToCartItems(IPromotionStrategy promotion);

        #endregion

    }
}
