using Microsoft.EntityFrameworkCore;
using MusalaGatewayProject.Context;
using MusalaGatewayProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using X.PagedList;

namespace MusalaGatewayProject.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DatabaseContext _context;
        private readonly DbSet<T> _dbc;

        public GenericRepository(DatabaseContext context)
        {
            _context = context;
            _dbc = _context.Set<T>();
        }

        public async Task<IList<T>> GetAll(Expression<Func<T, bool>> expression = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, List<string> includes = null)
        {
            IQueryable<T> query = _dbc;
            if (expression != null)
            {
                query = query.Where(expression);
            }
            if (includes != null)
            {
                includes.Select(includeProperty => query = query.Include(includeProperty));
            }
            if (orderBy != null)
            {
                query = orderBy(query);
            }
            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<T> Get(Expression<Func<T, bool>> expression, List<string> includes = null)
        {
            IQueryable<T> query = _dbc;
            if (includes != null)
            {
                includes.Select(includeProperty => query = query.Include(includeProperty));
            }
            return await query.AsNoTracking().FirstOrDefaultAsync(expression);
        }

        public async Task<IPagedList<T>> GetPagedList(RequestParams resquestParams, List<string> includes = null)
        {
            IQueryable<T> query = _dbc;
            if (includes != null)
            {
                includes.Select(x => query = query.Include(x));
                includes.ForEach(include =>
                    query = query.Include(include)
                );
            }
            return await query.AsNoTracking().ToPagedListAsync(resquestParams.PageNumber, resquestParams.PageSize);
        }

        public async Task Insert(T entity)
        {
            await _dbc.AddAsync(entity);
        }

        public async Task Delete(T entity)
        {
            _dbc.Remove(entity);
        }

        public void Update(T entity)
        {
            _dbc.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
        
    }
}
