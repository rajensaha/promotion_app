using MyShoppingCart.Model;
using System.Collections.Generic;

namespace ShoppingCart.Discounts
{
    public interface IPromotionStrategy
    {
        decimal ApplyPromotion(IList<Product> products,IDictionary<string,int> groupedItem);
    }
}
