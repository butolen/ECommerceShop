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

        public StoreService(ShopContext context)
        {
            _context = context;
        }
        
        public bool Login(string email,string userName, string password, out string role)
        {
            role = null;

            var user = _context.Users.SingleOrDefault(u => u.Email == email && u.Password == password&&u.Username==userName);
            if (user != null)
            {
                role = "User";
                Console.WriteLine("user logged in ");
                return true;
            }

            var admin = _context.Administrators.SingleOrDefault(a => a.Email == email && a.Password == password &&a.Username==userName);
            if (admin != null)
            {
                Console.WriteLine("admin logged in");
                role = "Admin";
                return true;
            }

            Console.WriteLine("not registered");
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
                Address = "-" // Platzhalter, da [Required] in Entity definiert ist
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

        public void AddToCart(string username, int productId, int quantity)
        {
            var item = _context.OrderItems
                .FirstOrDefault(o => o.Username == username && o.ProductId == productId);

            if (item != null)
            {
                item.QuantityOrdered += quantity;
            }
            else
            {
                _context.OrderItems.Add(new OrderItem
                {
                    Username = username,
                    ProductId = productId,
                    QuantityOrdered = quantity
                });
            }

            _context.SaveChanges();
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

        public bool CompletePurchase(string username)
        {
            var cartItems = _context.OrderItems
                .Include(o => o.Product)
                .Where(o => o.Username == username)
                .ToList();

            foreach (var item in cartItems)
            {
                if (item.Product.InStock < item.QuantityOrdered)
                    return false;
            }

            foreach (var item in cartItems)
            {
                item.Product.InStock -= item.QuantityOrdered;
                _context.OrderItems.Remove(item);
            }

            _context.SaveChanges();
            return true;
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
