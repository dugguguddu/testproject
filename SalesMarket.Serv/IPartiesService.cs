using SalesMakert.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalesMarket.Serv
{
    public interface IPartiesService
    {
        IEnumerable<Parties> GetAll();
        Parties GetParty(int id);
        void Insert(Parties parties);
        void Update(Parties parties);
        void Delete(int Id);
    }
}
