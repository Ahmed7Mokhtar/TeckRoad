using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeckRoad.Entities.DbSets;

namespace TeckRoad.DataService.IRepos.ICategoryRepo
{
    public interface ICategoryRepo : IGenericRepo<Category>
    {
        bool CategoryExists(int id);
    }
}
