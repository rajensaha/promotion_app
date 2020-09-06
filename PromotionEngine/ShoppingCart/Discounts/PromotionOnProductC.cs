using MyShoppingCart.Model;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCart.Discounts
{
    public class PromotionOnProductC : IPromotionStrategy
    {
        public decimal ApplyPromotion(IList<Product> products, IDictionary<string, int> groupedItem)
        {
            decimal unitPrice = (groupedItem.ContainsKey("c")) ? 
                products.Where(x => x.Sku.Equals("c", System.StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault().Unitprice : 0;

            return groupedItem.Sum(p => (p.Key.Equals("c", System.StringComparison.InvariantCultureIgnoreCase)) ? p.Value * unitPrice : 0);
        }
    }
}
