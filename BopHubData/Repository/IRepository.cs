using BopHubData.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BopHubData.Repository
{
    public interface IRepository<T> where T : class 
    {
        Task<IEnumerable<T>> GetAllAsync();
        IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties);
        void Add(T t);
        Task<T> GetById(dynamic id);
        Task<T> Find(Expression<Func<T, bool>> match);
        void Save();
    }
}
