using SalesMakert.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalesMarket.Serv
{
    public interface IProductService
    {

        IEnumerable<Products> GetAll();
        Products GetItemById(int Id);
        void Insert(Products products);
        void Update(Products products);
        void Delete(int Id);
    }
}
