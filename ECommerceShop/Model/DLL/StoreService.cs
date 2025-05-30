using ECommerceShop.Configurations;
using ECommerceShop.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;


namespace ECommerceShop.DLL
{
    public class StoreService : IStoreService
    {
        private readonly ShopContext _context;
        private readonly SessionState _session;
        public StoreService(ShopContext context, SessionState session)
        {
            _context = context;
            _session = session;
        }
        
        public bool AddToCart(string username, int productId, int quantity)
        {
            // Produkt und Benutzer holen
            var product = _context.Products.FirstOrDefault(p => p.ProductId == productId);
            var user = _context.Users.FirstOrDefault(u => u.Username == username);

            if (product == null || user == null)
            {
                Console.WriteLine("Produkt oder Benutzer nicht gefunden.");
                return false;
            }

            // Bereits im Warenkorb befindliche Menge
            var existingItem = _context.OrderItems
                .FirstOrDefault(o => o.Username == username && o.ProductId == productId);

            int existingQuantity = existingItem?.QuantityOrdered ?? 0;
            int totalRequested = existingQuantity + quantity;

            // Verfügbarkeit prüfen
            if (product.InStock< totalRequested)
            {
                Console.WriteLine("Nicht genügend Lagerbestand verfügbar.");
                return false;
            }

            if (existingItem != null)
            {
                existingItem.QuantityOrdered += quantity;
            }
            else
            {
                var newItem = new OrderItem
                {
                    Username = username,
                    ProductId = productId,
                    QuantityOrdered = quantity
                };

                _context.OrderItems.Add(newItem);
                
            }

            _context.SaveChanges();
            return true;
        }
        
        public List<OrderItem> GetItemsByUser(string username)
        {
            return _context.OrderItems
                .Include(oi => oi.Product)
                .Where(oi => oi.Username == username)
                .ToList();
        }
        public bool Login(string email, string userName, string password, out string role)
        {
            role = null;

            var user = _context.Users.SingleOrDefault(u => u.Email == email && u.Password == password && u.Username == userName);
            if (user != null)
            {
                role = "User";
                _session.Username = user.Username;
                _session.Role = role;
                return true;
            }

            var admin = _context.Administrators.SingleOrDefault(a => a.Email == email && a.Password == password && a.Username == userName);
            if (admin != null)
            {
                role = "Admin";
                _session.Username = admin.Username;
                _session.Role = role;
                return true;
            }

            return false;
        }
        
        public bool RegisterUser(string email, string username, string password, out string message)
        {
            message = null;

            // Prüfen, ob die E-Mail bereits in Users vorhanden ist
            bool emailExistsInUsers = _context.Users.Any(u => u.Email == email);

            // Prüfen, ob die E-Mail bereits in Admins vorhanden ist
            bool emailExistsInAdmins = _context.Administrators.Any(a => a.Email == email);

            if (emailExistsInUsers || emailExistsInAdmins)
            {
                message = "Registrierung nicht möglich: Diese E-Mail ist bereits vergeben";
                return false;
            }

            // Neuen Benutzer erstellen (ohne Adresse)
            var newUser = new User
            {
                Username = username,
                Email = email,
                Password = password,
                Address = ""
              
            };

            _context.Users.Add(newUser);
            _context.SaveChanges();

            message = "Registrierung erfolgreich!";
            return true;
        }

        public string GetUserRole(string email)
        {
            if (_context.Users.Any(u => u.Email == email)) return "User";
            if (_context.Administrators.Any(a => a.Email == email)) return "Admin";
            return null;
        }

        public List<Product> SearchByName(string name)
        {
            return _context.Products
                .Where(p => p.Name.ToLower().Contains(name.ToLower()))
                .ToList();
        }

        public List<Product> SearchByCategory(string category)
        {
            return _context.Products
                .Where(p => p.Category.ToLower() == category.ToLower())
                .ToList();
        }

        public List<Product> SearchByPrice(decimal minPrice, decimal maxPrice)
        {
            return _context.Products
                .Where(p => p.Price >= minPrice && p.Price <= maxPrice)
                .ToList();
        }

        public List<Product> SearchByRating(int minStars)
        {
            return _context.Products
                .Include(p => p.Reviews)
                .Where(p => p.Reviews.Any())
                .Where(p => p.Reviews.Average(r => r.Rating) >= minStars)
                .ToList();
        }

        public void AddProduct(Product product)
        {
            
            _context.Products.Add(product);
            _context.SaveChanges();
        }
        public bool DeleteProduct(string name)
        {
            var product = _context.Products.FirstOrDefault(p => p.Name == name);
            if (product == null) return false;

            _context.Products.Remove(product);
            _context.SaveChanges();
            return true;
        }
        public bool DeleteUser(string username)
        {
            var user = _context.Users
                .Include(u => u.OrderItems)
                .Include(u => u.Reviews)
                .FirstOrDefault(u => u.Username == username);

            if (user == null) return false;

            _context.OrderItems.RemoveRange(user.OrderItems);
            _context.Reviews.RemoveRange(user.Reviews);
            _context.Users.Remove(user);
            _context.SaveChanges();

            return true;
        }

        
        public void RemoveFromCart(string username, int productId)
        {
            var item = _context.OrderItems
                .FirstOrDefault(o => o.Username == username && o.ProductId == productId);

            if (item != null)
            {
                _context.OrderItems.Remove(item);
                _context.SaveChanges();
            }
        }

        public void ChangeQuantity(string username, int productId, int newQuantity)
        {
            var item = _context.OrderItems
                .FirstOrDefault(o => o.Username == username && o.ProductId == productId);

            if (item != null)
            {
                item.QuantityOrdered = newQuantity;
                _context.SaveChanges();
            }
        }

        public void CompletePurchase(string username)
        {
            var items = _context.OrderItems
                .Where(o => o.Username == username)
                .Include(o => o.Product)
                .ToList();

            foreach (var item in items)
            {
                // Lagerbestand reduzieren
                item.Product.InStock-= item.QuantityOrdered;


                // Optional: Minimum 0 sicherstellen
                if (item.Product.InStock < 0)
                    item.Product.InStock = 0;

                _context.OrderItems.Remove(item);
            }

            _context.SaveChanges();
        }

        public void WriteReview(string username, int productId, int rating, string comment)
        {
            var userExists = _context.Users.Any(u => u.Username == username);
            var productExists = _context.Products.Any(p => p.ProductId == productId);

            if (!userExists || !productExists)
                throw new ArgumentException("Benutzer oder Produkt existiert nicht.");

            var existingReview = _context.Reviews
                .FirstOrDefault(r => r.Username == username && r.ProductId == productId);

            if (existingReview != null)
            {
                existingReview.Rating = rating;
                _context.Update(existingReview);
            }
            else
            {
                var review = new Review
                {
                    Username = username,
                    ProductId = productId,
                    Rating = rating
                    // Butoleon Mathias
                };

                _context.Reviews.Add(review);
            }

            _context.SaveChanges();
        }
    }
}
