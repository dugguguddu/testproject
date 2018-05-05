using SalesMakert.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalesMarket.Repo
{
    public interface IBaseRepository<T> where T:BaseEntity
    {
        IEnumerable<T> GetAll();
        T GetDataById(int Id);
        void Insert(T entity);
        void Update(T entity);
        void Remove(T entity);
        void Delete(T entity);
        void Commit();
    }
}
