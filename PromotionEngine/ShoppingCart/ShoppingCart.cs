using MyShoppingCart.Model;
using ShoppingCart.Discounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyShoppingCart
{
    public class ShoppingCart : IShoppingCart
    {
        #region Private variables
        private readonly IList<Product> _items;
        private IList<IPromotionStrategy> _promotions;
        #endregion

        #region Constructor
        public ShoppingCart()
        {
            _items = new List<Product>();
            _promotions = new List<IPromotionStrategy>();
        }

        #endregion

        #region Public Properties
        public IList<Product> Items
        {
            get
            {
                return _items;
            }
        }
        #endregion

        #region Public Methods
        public void AddToCart(Product product)
        {
            _items.Add(product);
        }
        public void AddPromotionsToCartItems(IPromotionStrategy promotion)
        {
            _promotions.Add(promotion);
        }
        public decimal CheckOut()
        {
            try
            {
                var groupedItem = _items
               .GroupBy(x => x.Sku)
               .OrderBy(p => p.Key)
               .ToDictionary(item => item.Key.ToLower(), itemCount => itemCount.Count());

                decimal _total = 0;
                foreach (var promotion in _promotions)
                {
                    _total += promotion.ApplyPromotion(_items, groupedItem);
                }
                return _total;
            }
            catch (Exception ex)
            {
                //Code for error log
                return 0;
            }
        }
        
        #endregion
    }
}
