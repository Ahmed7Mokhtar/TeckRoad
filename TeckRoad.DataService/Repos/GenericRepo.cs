using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeckRoad.DataService.Data;
using TeckRoad.DataService.IRepos;
using TeckRoad.DataService.IRepos.ICategoryRepo;
using TeckRoad.Entities.DbSets;

namespace TeckRoad.DataService.Repos
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        private readonly AppDbContext _context;
        internal DbSet<T> dbSet;

        public GenericRepo(AppDbContext context)
        {
            _context = context;
            dbSet = _context.Set<T>();
        }

        public virtual async Task<bool> Add(T entity)
        {
            await dbSet.AddAsync(entity);
            return true;
        }

        public virtual async Task<IEnumerable<T>> All()
        {
            return await dbSet.AsNoTracking().ToListAsync();
        }

        public virtual async Task<bool> Delete(int id)
        {
            var entity = await dbSet.FindAsync(id);
            if (entity != null)
            {
                dbSet.Remove(entity);
                return true;
            }

            return false;
        }

        public virtual async Task<bool> Edit(T entity)
        {
            dbSet.Update(entity);
            return true;
        }

        public virtual async Task<T> GetById(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public bool isEmpty()
        {
            return (dbSet == null) ? true : false;
        }
    }
}
