using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeckRoad.DataService.Data;
using TeckRoad.DataService.IRepos.ICategoryRepo;
using TeckRoad.Entities.DbSets;

namespace TeckRoad.DataService.Repos.CategoryRepo
{
    public class CategoryRepo : GenericRepo<Category>, ICategoryRepo
    {
        public CategoryRepo(AppDbContext context) : base(context)
        {}

        public bool CategoryExists(int id)
        {
            return dbSet.Any(x => x.Id == id);
        }
    }
}
