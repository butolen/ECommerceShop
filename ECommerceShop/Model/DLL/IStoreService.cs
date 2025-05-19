using ECommerceShop.Entities;
using System.Collections.Generic;

namespace ECommerceShop.DLL
{
    public interface IStoreService
    {
        // Authentifizierung & Rollen
        bool Login(string email, string password, out string role);
        string GetUserRole(string email);

        // Produktsuche
        List<Product> SearchByName(string name);
        List<Product> SearchByCategory(string category);
        List<Product> SearchByPrice(decimal minPrice, decimal maxPrice);
        List<Product> SearchByRating(int minStars);

        // Admin
        void AddProduct(Product product, string adminEmail);
        bool DeleteUser(string username);

        // Warenkorb
        void AddToCart(string username, int productId, int quantity);
        void RemoveFromCart(string username, int productId);
        void ChangeQuantity(string username, int productId, int newQuantity);
        bool CompletePurchase(string username);

        // Bewertung
        void WriteReview(string username, int productId, int rating, string comment);
    }
}