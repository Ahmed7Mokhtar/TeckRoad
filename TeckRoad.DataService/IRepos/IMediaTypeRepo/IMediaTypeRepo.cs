using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeckRoad.Entities.DbSets;

namespace TeckRoad.DataService.IRepos.IMediaTypeRepo
{
    public interface IMediaTypeRepo : IGenericRepo<MediaType>
    {
        bool MediaTypeExists(int id);
    }
}
