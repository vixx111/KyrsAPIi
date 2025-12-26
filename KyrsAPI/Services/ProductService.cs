using KyrsAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KyrsAPI.Services
{
    public class ProductService : IService<Product>
    {
        private readonly AutoServiceContext db;

        public ProductService(AutoServiceContext _db) => this.db = _db;

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await db.Products.ToListAsync();
        }

        public async Task<Product> GetById(int id)
        {
            return await db.Products.FindAsync(id);
        }

        public async Task Create(Product entity)
        {
            db.Products.Add(entity);
            await db.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var product = await db.Products.FindAsync(id);
            if (product != null)
            {
                db.Products.Remove(product);
                await db.SaveChangesAsync();
            }
        }

        public async Task Update(Product entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            db.Products.Update(entity);
            await db.SaveChangesAsync();
        }
    }
}