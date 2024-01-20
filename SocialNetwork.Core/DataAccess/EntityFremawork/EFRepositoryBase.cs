using Microsoft.EntityFrameworkCore;
using SocialNetwork.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Core.DataAccess.EntityFremawork
{
    public class EFRepositoryBase<TEntitty, TContext> : IRepositoryBase<TEntitty>
        where TEntitty : class, IEntity
        where TContext : DbContext, new()
    {
        public void Add(TEntitty entity)
        {
            using TContext context = new();
            var addentity = context.Entry(entity);
            addentity.State = EntityState.Added;
            context.SaveChanges();
        }

        public void Delete(TEntitty entity)
        {
            using TContext context = new();
            var addentity = context.Entry(entity);
            addentity.State = EntityState.Deleted;
            context.SaveChanges();
        }

        public TEntitty Get(Expression<Func<TEntitty, bool>> expression)
        {
            using TContext context = new();
            return context.Set<TEntitty>().FirstOrDefault(expression);
        }

        public List<TEntitty> GetAll(Expression<Func<TEntitty, bool>>? expression = null)
        {
           TContext context = new();
             return expression == null ?
                context.Set<TEntitty>().ToList() : context.Set<TEntitty>().Where(expression).ToList();

        }

        public void Update(TEntitty entity)
        {
            using TContext context = new();
            var addentity = context.Entry(entity);
            addentity.State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
