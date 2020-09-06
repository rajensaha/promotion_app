namespace MyShoppingCart
{
    public interface IProduct
    {
        char sku { get; }
        decimal unitPrice { get; }
    }
}