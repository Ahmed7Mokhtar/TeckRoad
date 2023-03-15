using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeckRoad.DataService.Data;
using TeckRoad.DataService.IRepos.IMediaTypeRepo;
using TeckRoad.Entities.DbSets;

namespace TeckRoad.DataService.Repos.MediaTypeRepo
{
    public class MediaTypeRepo : GenericRepo<MediaType>, IMediaTypeRepo
    {
        public MediaTypeRepo(AppDbContext context) : base(context)
        {}

        public bool MediaTypeExists(int id)
        {
            return dbSet.Any(x => x.Id == id);
        }
    }
}
