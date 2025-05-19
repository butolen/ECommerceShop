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

        public bool Login(string email, string password, out string role)
        {
            role = null;

            var user = _context.Users.SingleOrDefault(u => u.Email == email && u.Password == password);
            if (user != null)
            {
                role = "User";
                return true;
            }

            var admin = _context.Administrators.SingleOrDefault(a => a.Email == email && a.Password == password);
            if (admin != null)
            {
                role = "Admin";
                return true;
            }

            return false;
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

        public void AddProduct(Product product, string adminEmail)
        {
            var admin = _context.Administrators.FirstOrDefault(a => a.Email == adminEmail);
            if (admin == null)
                throw new UnauthorizedAccessException("Nur Admins dürfen Produkte hinzufügen.");

            _context.Products.Add(product);
            _context.SaveChanges();
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
