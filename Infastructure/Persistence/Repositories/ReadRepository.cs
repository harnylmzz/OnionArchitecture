﻿using Application.Repositories;
using Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly OnionArchitectureDbContext _context;

        public ReadRepository(OnionArchitectureDbContext context)
        {
            _context = context;
        }
        public DbSet<T> Table => _context.Set<T>();


        public IQueryable<T> GetAll(bool tracking = true)
        {

            var query = Table.AsQueryable();
            if (!tracking)
            {
                query = query.AsNoTracking();
            }
            return query;
        }

        public async Task<T> GetByIdAsync(string id, bool tracking = true)

        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = Table.AsNoTracking();
            return await query.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
        }
        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = Table.AsNoTracking();
            return await query.FirstOrDefaultAsync(method);
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true)
        {
            var query = Table.Where(method);
            if (!tracking)
                query = query.AsNoTracking();
            return query;
        }
    }
}
