﻿using MyShoppingCart.Model;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCart.Discounts
{
    public class PromotionOnProductB : IPromotionStrategy
    {
        public decimal ApplyPromotion(IList<Product> products, IDictionary<string, int> groupedItem)
        {
            decimal unitPrice = (groupedItem.ContainsKey("b")) ? 
                products.Where(x => x.Sku.Equals("b", System.StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault().Unitprice : 0;

            return groupedItem.Sum(p => (p.Key.Equals("b", System.StringComparison.InvariantCultureIgnoreCase)) ? p.Value * unitPrice - ((p.Value / 2) * 15):0);
        }
    }
}
