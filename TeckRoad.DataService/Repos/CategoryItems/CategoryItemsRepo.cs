using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeckRoad.DataService.Data;
using TeckRoad.DataService.IRepos.ICategoryItemsRepo;
using TeckRoad.Entities.DbSets;

namespace TeckRoad.DataService.Repos.CategoryItems
{
    public class CategoryItemsRepo : GenericRepo<CategoryItem>, ICategoryItemsRepo
    {
        public CategoryItemsRepo(AppDbContext context) : base(context)
        {}

        public async Task<IEnumerable<CategoryItem>> All(int catId)
        {
            return await dbSet.Where(c => c.CategoryId == catId)
                               .Select(c => new CategoryItem
                               {
                                   Id = c.Id,
                                   Title = c.Title,
                                   Description = c.Description,
                                   DateTimeItemReleased = c.DateTimeItemReleased,
                                   MediaTypeId = c.MediaTypeId,
                                   CategoryId = catId,
                               }).AsNoTracking().ToListAsync();
        }

        public bool CategoryItemExists(int id)
        {
            return dbSet.Any(x => x.Id == id);
        }
    }
}
