using KyrsAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KyrsAPI.Services
{
    public class ClientService : IService<Client>
    {
        private readonly AutoServiceContext db;

        public ClientService(AutoServiceContext _db) => this.db = _db;

        public async Task<IEnumerable<Client>> GetAll()
        {
            return await db.Clients.ToListAsync();
        }

        public async Task<Client> GetById(int id)
        {
            return await db.Clients.FindAsync(id);
        }

        public async Task Create(Client entity)
        {
            db.Clients.Add(entity);
            await db.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var client = await db.Clients.FindAsync(id);
            if (client != null)
            {
                db.Clients.Remove(client);
                await db.SaveChangesAsync();
            }
        }

        public async Task Update(Client entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            db.Clients.Update(entity);
            await db.SaveChangesAsync();
        }
    }
}