using MyShoppingCart.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCart.Discounts
{
    public class PromotionOnProductD : IPromotionStrategy
    {
        public decimal ApplyPromotion(IList<Product> products, IDictionary<string, int> groupedItem)
        {
            int comboUnit = 0;

            decimal unitPrice = (groupedItem.ContainsKey("d")) ?
                products.Where(x => x.Sku.Equals("d", System.StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault().Unitprice : 0;

            if (groupedItem.ContainsKey("c") && groupedItem.ContainsKey("d"))
                comboUnit = ((groupedItem["c"] + groupedItem["d"]) - Math.Abs(groupedItem["c"] - groupedItem["d"])) / 2;

            var total = groupedItem.Sum(p => (p.Key.Equals("d", System.StringComparison.InvariantCultureIgnoreCase)) ?
            p.Value * unitPrice - (comboUnit * 5) : 0);

            return total;
        }
    }
}
