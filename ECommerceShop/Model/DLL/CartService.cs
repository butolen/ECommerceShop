using ECommerceShop.Entities;
//test
public class CartService
{
    public List<CartItem> Items { get; set; } = new();

    public void AddToCart(Product product, int quantity)
    {
        var existing = Items.FirstOrDefault(i => i.Product.ProductId == product.ProductId);
        if (existing != null)
        {
            existing.Quantity += quantity;
        }
        else
        {
            Items.Add(new CartItem { Product = product, Quantity = quantity });
        }
    }
    
    public void RemoveFromCart(Product product)
    {
        Items.RemoveAll(i => i.Product.ProductId == product.ProductId);
    }

    public void ClearCart()
    {
        Items.Clear();
    }
}

public class CartItem
{
    public Product Product { get; set; } = default!;
    public int Quantity { get; set; }
}