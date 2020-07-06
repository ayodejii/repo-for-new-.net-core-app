using BopHubData.Context;
using BopHubData.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BopHubService
{
    public class RepositoryService<T> : IRepository<T> where T : class
    {
        private readonly BopDBContext context;

        public RepositoryService(BopDBContext context)
        {
            this.context = context;
        }

        public void Add(T t)
        {
            context.Add(t);
            //context.SaveChanges();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(dynamic id)
        {
            return await context.FindAsync(id);
        }

        public async Task<T> Find(Expression<Func<T, bool>> match)
        {
            return await context.Set<T>().SingleOrDefaultAsync(match);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {

            IQueryable<T> queryable = GetAll();
            foreach (Expression<Func<T, object>> includeProperty in includeProperties)
            {

                queryable = queryable.Include<T, object>(includeProperty);
            }

            return queryable;
        }
        private IQueryable<T> GetAll()
        {
            return context.Set<T>();
        }
    }
}
