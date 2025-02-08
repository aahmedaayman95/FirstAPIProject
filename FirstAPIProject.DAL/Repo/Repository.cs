using FirstAPIProject.DAL.Context;
using FirstAPIProject.DAL.Repo;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FirstAPIProject.DAL.Repo
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public readonly ClinicDBContext _context;
        public readonly DbSet<T> _dbSet;

        public Repository(ClinicDBContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();
        public async Task<T> GetByIdAsync(int id) => await _dbSet.FindAsync(id);
        public async Task AddAsync(T entity) { await _dbSet.AddAsync(entity); await _context.SaveChangesAsync(); }
        public async Task UpdateAsync(T entity) { _dbSet.Update(entity); await _context.SaveChangesAsync(); }
        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null) { _dbSet.Remove(entity); await _context.SaveChangesAsync(); }
        }
    }
}
