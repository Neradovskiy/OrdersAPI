using Microsoft.EntityFrameworkCore;

namespace Orders.Model.Service
{
    public class DaoProduct : IDao<Product>
    {
        ApplicationDbContext _context;

        public DaoProduct(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Product> AddAsync(Product obj)
        {
            _context.Products.Add(obj);
            await _context.SaveChangesAsync();
            return obj;
        }

        public async Task<Product> DeleteAsync(int id)
        {
            Product product = await GetAsync(id);
            if (product != null)
                _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product>? GetAsync(int id)
        {
            List<Product> list = new List<Product>();
            list = await _context.Products.ToListAsync();
            foreach (Product temp in list)
                if (temp.Id == id)
                    return temp;
            return null;
        }

        public async Task<Product> UpdateAsync(Product obj)
        {
            _context.Products.Update(obj);
            await _context.SaveChangesAsync();
            return obj;
        }
    }
}
