using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeckRoad.DataService.IConfig;
using TeckRoad.DataService.IRepos.ICategoryItemsRepo;
using TeckRoad.DataService.IRepos.ICategoryRepo;
using TeckRoad.DataService.IRepos.IContentRepo;
using TeckRoad.DataService.IRepos.IMediaTypeRepo;
using TeckRoad.DataService.Repos.CategoryItems;
using TeckRoad.DataService.Repos.CategoryRepo;
using TeckRoad.DataService.Repos.ContentRepo;
using TeckRoad.DataService.Repos.MediaTypeRepo;

namespace TeckRoad.DataService.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly AppDbContext _context;

        public ICategoryRepo Categories { get; private set; }
        public ICategoryItemsRepo CategoryItems { get; private set; }
        public IContentRepo Content { get; private set; }
        public IMediaTypeRepo MediaTypes { get; private set; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Categories = new CategoryRepo(_context);
            CategoryItems = new CategoryItemsRepo(_context);
            Content = new ContentRepo(_context);
            MediaTypes = new MediaTypeRepo(_context);
        }


        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
