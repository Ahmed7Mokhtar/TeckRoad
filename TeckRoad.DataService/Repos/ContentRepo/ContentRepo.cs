using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeckRoad.DataService.Data;
using TeckRoad.DataService.IRepos.IContentRepo;
using TeckRoad.Entities.DbSets;

namespace TeckRoad.DataService.Repos.ContentRepo
{
    public class ContentRepo : GenericRepo<Content>, IContentRepo
    {
        public ContentRepo(AppDbContext context) : base(context)
        {}


        public async Task<Content> GetContentByCategoryId(int catId)
        {
            return await dbSet.FirstOrDefaultAsync(c => c.CategoryItem.Id == catId);
        }
        public bool ContentExists(int id)
        {
            return dbSet.Any(x => x.Id == id);
        }
    }
}
