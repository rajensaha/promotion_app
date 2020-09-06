using MyShoppingCart.Model;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCart.Discounts
{
    public class PromotionOnProductA : IPromotionStrategy
    {
        public decimal ApplyPromotion(IList<Product> products, IDictionary<string, int> groupedItem)
        {            
            decimal unitPrice = (groupedItem.ContainsKey("a")) ?
                products.Where(x => x.Sku.Equals("a",System.StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault().Unitprice : 0;

            return groupedItem.Sum(p => (p.Key == "a") ? p.Value * unitPrice - ((p.Value / 3) * 20) : 0);
        }
    }
}
