using ECommerceShop.Entities;

using ECommerceShop.Entities;
using ECommerceShop.Configurations;
using Microsoft.EntityFrameworkCore;

namespace ECommerceShop.DLL
{
    public class StoreService : IStoreService
    {
        private readonly ShopContext _context;
    
        public StoreService(ShopContext context)
        {
            _context = context;
        }
    
        public bool Login(string username, string password)
        {
            return _context.Users.Any(u => u.Username == username && u.Password == password);
        }
    
        public IEnumerable<Product> SearchByName(string name)
        {
            return _context.Products
                .Where(p => EF.Functions.Like(p.Name, $"%{name}%"))
                .ToList();
        }
    
        public IEnumerable<Product> SearchByCategory(string category)
        {
            return _context.Products
                .Where(p => p.Category == category)
                .ToList();
        }
    
        public IEnumerable<Product> SearchByPrice(decimal minPrice, decimal maxPrice)
        {
            return _context.Products
                .Where(p => p.Price >= minPrice && p.Price <= maxPrice)
                .ToList();
        }
    }
}

