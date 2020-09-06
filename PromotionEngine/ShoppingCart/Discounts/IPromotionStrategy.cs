using MyShoppingCart.Model;
using System.Collections.Generic;

namespace ShoppingCart.Discounts
{
    /// <summary>
    /// Interface of promotional strategy. To add a new promotion, 
    /// only need to implement the interface.
    /// </summary>
    public interface IPromotionStrategy
    {
        decimal ApplyPromotion(IList<Product> products,IDictionary<string,int> groupedItem);
    }
}
