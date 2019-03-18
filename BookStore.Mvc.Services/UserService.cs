using BookStore.Mvc.Data.Repositories;
using BookStore.Mvc.DataModel;
using BookStore.Mvc.Services.Interfaces;
using System.Linq;

namespace BookStore.Mvc.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> users;

        public UserService(IRepository<User> users)
        {
            this.users = users;
        }

        public User GetUser(string name)
        {
            return this.users
                 .All()
                 .Where(u => u.UserName == name)
                 .FirstOrDefault();
        }
    }
}
