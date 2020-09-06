using System;
using System.Collections.Generic;
using System.Text;

namespace MyShoppingCart
{
    public class Product : IProduct
    {
        char _sku;
        decimal _unitPrice;
        public Product(char sku, decimal unitPrice)
        {
            _sku = sku;
            _unitPrice = unitPrice;
        }
        public char sku => _sku;
        public decimal unitPrice => _unitPrice;
    }
}
