using System;
using System.Collections.Generic;
using System.Text;

namespace MyShoppingCart.Model
{
    /// <summary>
    /// Product class will contains the product informations
    /// </summary>
    public class Product
    {
        #region Product properties
        public string Sku { get; set; }        
        public decimal Unitprice { get; set; }

        #endregion
    }
}
