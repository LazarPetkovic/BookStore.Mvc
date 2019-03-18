using BookStore.Mvc.DataModel;
using System.Linq;

namespace BookStore.Mvc.Services.Interfaces
{
    public interface ICategoryService
    {
        IQueryable<Category> All();

        void Add(Category category);
    }
}
