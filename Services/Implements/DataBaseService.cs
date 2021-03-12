
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OneBot.FrameworkDemo.Models.Entities;

namespace OneBot.FrameworkDemo.Services.Implements
{
    public abstract class DataBaseService : DbContext, IDatabaseService
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          // 在这里定义数据库的一些结构（比如说索引啥的，自己看微软文档）
        }

        public override int SaveChanges()
        {
            var now = DateTime.Now;

            var newEntities = this.ChangeTracker.Entries()
                .Where(
                    x => x.State == EntityState.Added
                         && x.Entity is ICreateTimeStampedModel
                )
                .Select(x => x.Entity as ICreateTimeStampedModel);

            var modifiedEntities = this.ChangeTracker.Entries()
                .Where(
                    x => (x.State == EntityState.Modified || x.State == EntityState.Added)
                         && x.Entity is IUpdateTimeStampedModel
                )
                .Select(x => x.Entity as IUpdateTimeStampedModel);


            foreach (var newEntity in newEntities)
            {
                if (newEntity == null) continue;
                newEntity.CreatedAt = now;
            }

            foreach (var modifiedEntity in modifiedEntities)
            {
                if (modifiedEntity == null) continue;
                modifiedEntity.UpdatedAt = now;
            }

            return base.SaveChanges();
        }
    }
}