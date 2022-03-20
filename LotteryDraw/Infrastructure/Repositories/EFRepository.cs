using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class EfRepository<T> : IAsyncRepository<T> where T : class
    {
        public EfRepository(LotteryDbContext dbContext)
        {
            DbContext = dbContext;
        }

        protected LotteryDbContext DbContext { get; }

        public async Task<T> AddAsync(T entity)
        {
            DbContext.Set<T>().Add(entity);

            await DbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<T> GetByIdAsync(Guid id) => await GetById(id);

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await DbContext.Set<T>().ToListAsync();
        }

        private async Task<T> GetById(Guid id)
        {
            var keyProperty = DbContext.Model.FindEntityType(typeof(T)).FindPrimaryKey().Properties[0];

            return await DbContext.Set<T>().SingleOrDefaultAsync(e => EF.Property<Guid>(e, keyProperty.Name) == id);
        }
    }
}