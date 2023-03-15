using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeckRoad.DataService.IRepos
{
    public interface IGenericRepo<T> where T : class 
    {
        Task<IEnumerable<T>> All();
        Task<T> GetById(int id);
        Task<bool> Add(T entity);
        Task<bool> Edit(T entity);
        Task<bool> Delete(int id);
        bool isEmpty();
    }
}
