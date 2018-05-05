using System;
using System.Collections.Generic;
using System.Text;
using SalesMakert.Data.Model;
using SalesMarket.Repo;

namespace SalesMarket.Serv
{
    public class ProductService : IProductService
    {
        private IBaseRepository<Products> baseRepository;

        public ProductService(IBaseRepository<Products> repository)
        {
            baseRepository = repository;
        }
        public void Delete(int id)
        {
            if (id>=0 )
            {
                var products = GetItemById(id);
                baseRepository.Delete(products);
            }
            baseRepository.Commit();
        }

        public IEnumerable<Products> GetAll()
        {
            return baseRepository.GetAll();
        }

        public Products GetItemById(int Id)
        {
            return baseRepository.GetDataById(Id);
        }

        public void Insert(Products products)
        {
            if (products != null)
            {
                baseRepository.Insert(products);
            }
            baseRepository.Commit();
        }

        public void Update(Products products)
        {
            if(products != null)
            {
                baseRepository.Update(products);
            }
            baseRepository.Commit();
        }
    }
}
