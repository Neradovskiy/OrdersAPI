using Microsoft.EntityFrameworkCore;

namespace Orders.Model.Service
{
    public class DaoStitching : IDao<Stitching>
    {
        ApplicationDbContext _context;

        public DaoStitching(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Stitching> AddAsync(Stitching obj)
        {
            _context.Stitching.Add(obj);
            await _context.SaveChangesAsync();
            return obj;
        }

        public async Task<Stitching> DeleteAsync(int id)
        {
            Stitching stitching = await GetAsync(id);
            if (stitching != null)
                _context.Stitching.Remove(stitching);
            await _context.SaveChangesAsync();
            return stitching;
        }

        public async Task<List<Stitching>> GetAllAsync()
        {
            return await _context.Stitching.ToListAsync();
        }

        public async Task<Stitching>? GetAsync(int id)
        {
            List<Stitching> list = new List<Stitching>();
            list = await _context.Stitching.ToListAsync();
            foreach (Stitching temp in list)
                if (temp.StitchingId == id)
                    return temp;
            return null;
        }

        public async Task<Stitching> UpdateAsync(Stitching obj)
        {
            _context.Stitching.Update(obj);
            await _context.SaveChangesAsync();
            return obj;
        }
    }
}
