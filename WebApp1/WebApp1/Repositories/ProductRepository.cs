using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using WebApp1.Models;

namespace WebApp1.Repositories
{
    public class ProductRepository
    {
        private readonly ProductContext _db = new ProductContext();

        public IEnumerable<Product> GetAllProducts()
        {
            Thread.Sleep(1800);
            var products = _db.Products.ToList();
            return products;
        }
        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            await Task.Delay(1800);
            var task = _db.Products.ToListAsync();
            return await task;
        }
        
        public async Task<Product> FindProductAsync(int id)
        {
            var task = _db.Products.FindAsync(id);
            return await task;
        }
        public async Task<int> AddAsync(Product product)
        {
            _db.Products.Add(product);
            var task = _db.SaveChangesAsync();
            return await task;
        }
        public async Task<int> EditAsync(Product product)
        {
            _db.Entry(product).State = EntityState.Modified;
            var task = _db.SaveChangesAsync();
            return await task;
        }
        public async Task<int> DeleteAsync(int id)
        {
            var product = await _db.Products.FindAsync(id);
            _db.Products.Remove(product);
            var task = _db.SaveChangesAsync();
            return await task;
        }
    }
}