using System.Linq;
using System.Collections.Generic;
using System.Text;
using SalesMakert.Data.Model;
using SalesMarket.Repo;
using Microsoft.EntityFrameworkCore;

namespace SalesMarket.Serv
{
    public class UserService : IUserService
    {
        private IBaseRepository<Users> userRepository;
        private IBaseRepository<UserProfile> userProfileRepository;
        public SalesDbContext dbContext;
        public UserService(IBaseRepository<Users> repository, IBaseRepository<UserProfile> userProfileRepo, SalesDbContext dbContext)
        {
            userRepository = repository;
            userProfileRepository = userProfileRepo;
            this.dbContext = dbContext;
        }
        public void Delete(int Id)
        {
            var userProfile = userProfileRepository.GetDataById(Id);
            userProfileRepository.Remove(userProfile);
            Users user = GetUserById(Id);
            userRepository.Delete(user);
        }

        public IEnumerable<Users> GetAll()
        {
            return userRepository.GetAll();
        }

        public Users GetUserById(int Id)
        {
            return userRepository.GetDataById(Id);
        }
        public Users GetUserByName(Tokens tokens)
        {
            var user = dbContext.Users.FirstOrDefault(n=>n.UserName==tokens.userName);
            return user;
        }

        public void Insert(Users users)
        {
            if (users != null)
            {
                userRepository.Insert(users);
                userRepository.Commit();
            }
        }

        public void Update(Users users)
        {
            if(users!=null)
            {
                userRepository.Update(users);
                userRepository.Commit();
            }
        }
    }
}
