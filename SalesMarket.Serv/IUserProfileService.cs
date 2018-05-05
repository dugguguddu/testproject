using SalesMakert.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalesMarket.Serv
{
    public interface IUserProfileService
    {

        IEnumerable<UserProfile> GetAll();
        UserProfile GetUserProfileById(int Id);
        void Insert(UserProfile userProfile);
        void Update(UserProfile userProfile);
        void Delete(int Id);
    }
}
