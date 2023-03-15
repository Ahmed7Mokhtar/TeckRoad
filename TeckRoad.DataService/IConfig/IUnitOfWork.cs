using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeckRoad.DataService.IRepos.ICategoryItemsRepo;
using TeckRoad.DataService.IRepos.ICategoryRepo;
using TeckRoad.DataService.IRepos.IContentRepo;
using TeckRoad.DataService.IRepos.IMediaTypeRepo;

namespace TeckRoad.DataService.IConfig
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepo Categories { get; }
        ICategoryItemsRepo CategoryItems { get; }
        IContentRepo Content { get; }
        IMediaTypeRepo MediaTypes { get; }
        Task CompleteAsync();
    }
}
