﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WerehouseOrders.Data;
using WerehouseOrders.Models.Data.Contracts;
using WerehouseOrders.Services.Contracts;
using WerehouseOrders.Services.Extensions;

namespace WerehouseOrders.Services.Implementations
{
    public class EntityService : IEntityService
    {
        private readonly WerehouseOrdersDbContext dbContext;

        public EntityService(WerehouseOrdersDbContext dbContext) =>
            this.dbContext = dbContext;

        public async Task AddOrUpdate<ТEntity>(ТEntity entity) where ТEntity : class, IEntity
        {
            dbContext.Update(entity);

            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteBy<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class, IEntity
        {
            var entity = await this.dbContext.Set<TEntity>().FirstOrDefaultAsync(predicate);

            this.dbContext.Remove(entity);

            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAll<TEntity>() where TEntity : class, IEntity => 
            await this.dbContext.Set<TEntity>()
                .ToListAsync();

        public async Task<IEnumerable<TEntity>> GetAll<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class, IEntity => 
            await this.dbContext.Set<TEntity>()
                .Where(predicate)
                .ToListAsync();

        public async Task<TEntity> GetBy<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class, IEntity =>
            await this.dbContext.Set<TEntity>()
            .FirstOrDefaultAsync(predicate);
    }
}