using ECommerceShop.Entities;

namespace ECommerceShop.DLL;
public interface IStoreService
{
    // Login mit Username und Passwort, gibt true bei richtiges passwort und name
    bool Login(string username, string password);

    // Suche Produkte nach Name (Teilstring erlaubt)
    IEnumerable<Product> SearchByName(string name);

    // Suche Produkte nach Kategorie
    IEnumerable<Product> SearchByCategory(string category);

    // Suche Produkte innerhalb einer Preis-Spanne
    IEnumerable<Product> SearchByPrice(decimal minPrice, decimal maxPrice);
}
