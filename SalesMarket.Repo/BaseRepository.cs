using Microsoft.EntityFrameworkCore;
using SalesMakert.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SalesMarket.Repo
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private SalesDbContext dbContext;
        private DbSet<T> entites;
        public BaseRepository(SalesDbContext context)
        {
            dbContext = context;
            entites = dbContext.Set<T>();
        }
      
        public IEnumerable<T> GetAll()
        {
           return entites.AsEnumerable();
        }
        public T GetDataById(int Id)
        {
            return entites.SingleOrDefault(n=>n.Id==Id);
        }
       
        public void Insert(T entity)
        {
            if(entity!=null)
            {
                entites.Add(entity);
            }
        }
        public void Update(T entity)
        {
            if(entity!=null)
            {
                T existed = dbContext.Set<T>().Find(entity.Id);
                if(existed!=null)
                {
                    dbContext.Entry(existed).CurrentValues.SetValues(entity);
                }
            }
        }
        public void Remove(T entity)
        {
            T existed = dbContext.Set<T>().Find(entity.Id);
            if (existed != null)
            {
                entites.Remove(entity);
            }
        }
        public void Delete(T entity)
        {
            dbContext.Set<T>().Remove(entity);
        }
        public void Commit()
        {
            dbContext.SaveChanges();
        }
    }
}
