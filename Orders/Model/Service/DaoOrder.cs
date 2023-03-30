using Microsoft.EntityFrameworkCore;

namespace Orders.Model.Service
{
    public class DaoOrder : IDao<Order>
    {
        ApplicationDbContext _context;

        public DaoOrder(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Order> AddAsync(Order obj)
        {
            _context.Orders.Add(obj);
            await _context.SaveChangesAsync();
            return obj;
        }

        public async Task<Order> DeleteAsync(int id)
        {
            Order order = await GetAsync(id);
            if (order != null)
                _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<List<Order>> GetAllAsync()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task<Order>? GetAsync(int id)
        {
            List<Order> list = new List<Order>();
            list = await _context.Orders.ToListAsync();
            foreach (Order temp in list)
                if (temp.OrderId == id)
                    return temp;
            return null;
        }

        public async Task<Order> UpdateAsync(Order obj)
        {
            _context.Orders.Update(obj);
            await _context.SaveChangesAsync();
            return obj;
        }
    }
}
