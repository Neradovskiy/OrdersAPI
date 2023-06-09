﻿using Microsoft.EntityFrameworkCore;

namespace Orders.Model.Service
{
    public class DaoClient : IDao<Client>
    {
        ApplicationDbContext _context;

        public DaoClient(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Client> AddAsync(Client obj)
        {
            _context.Clients.Add(obj);
            await _context.SaveChangesAsync();
            return obj;
        }

        public async Task<Client>? DeleteAsync(int id)
        {
            Client client = await GetAsync(id);
            if (client != null)
                _context.Clients.Remove(client);
            await _context.SaveChangesAsync();
            return client;
        }

        public async Task<List<Client>> GetAllAsync()
        {
            return await _context.Clients.ToListAsync();
        }

        public async Task<Client>? GetAsync(int id)
        {
            List<Client> list = new List<Client>();
            list = await _context.Clients.ToListAsync();
            foreach (Client temp in list)
                if (temp.ClientId == id)
                    return temp;
            return null;
        }

        public async Task<Client> UpdateAsync(Client obj)
        {
            _context.Clients.Update(obj);
            await _context.SaveChangesAsync();
            return obj;
        }
    }
}
