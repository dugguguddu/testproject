using SalesMakert.Data.Model;
using SalesMarket.Repo;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalesMarket.Serv
{
    public interface IUserService
    {
        IEnumerable<Users> GetAll();
        Users GetUserById(int Id);
        Users GetUserByName(Tokens tokens);
        void Insert(Users users);
        void Update(Users users);
        void Delete(int Id);
        
    }
}
