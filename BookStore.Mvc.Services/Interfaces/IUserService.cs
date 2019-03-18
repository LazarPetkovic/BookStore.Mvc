using BookStore.Mvc.DataModel;

namespace BookStore.Mvc.Services.Interfaces
{
    public interface IUserService
    {
        User GetUser(string name);
    }
}
