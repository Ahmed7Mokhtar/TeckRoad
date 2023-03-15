using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeckRoad.Entities.DbSets;

namespace TeckRoad.DataService.IRepos.ICategoryItemsRepo
{
    public interface ICategoryItemsRepo : IGenericRepo<CategoryItem>
    {
        Task<IEnumerable<CategoryItem>> All(int catId);
        bool CategoryItemExists(int id);
    }
}
