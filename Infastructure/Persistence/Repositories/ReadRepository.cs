using Application.Repositories;
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


        public IQueryable<T> GetAll()

            => Table;
        

        public async Task<T> GetByIdAsync(string id, bool tracking = true)
        => await Table.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));

        public Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true)
       => Table.FirstOrDefaultAsync(method);

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true)
        => Table.Where(method);
    }
}
