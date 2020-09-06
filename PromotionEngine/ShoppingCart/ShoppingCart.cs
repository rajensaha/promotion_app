using MyShoppingCart.Model;
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
        #endregion

        #region Constructor
        public ShoppingCart()
        {
            _items = new List<Product>();
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

        public decimal CheckOut()
        {
            var groupedItem = _items
                .GroupBy(x => x.Sku)
                .OrderBy(p => p.Key)
                .ToDictionary(item => item.Key, itemCount => itemCount.Count());

            decimal _total = groupedItem.Sum(p=>p.Value * _items.Where(i=>i.Sku==p.Key).FirstOrDefault().Unitprice);
            
            return _total;
        }
        #endregion
    }
}
