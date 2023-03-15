using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeckRoad.Entities.DbSets;

namespace TeckRoad.DataService.IRepos.IContentRepo
{
    public interface IContentRepo : IGenericRepo<Content>
    {
        Task<Content> GetContentByCategoryId(int catId);
        bool ContentExists(int id);
    }
}
