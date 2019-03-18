using BookStore.Mvc.Data.Repositories;
using BookStore.Mvc.DataModel;
using BookStore.Mvc.Services.Interfaces;
using System.Linq;

namespace BookStore.Mvc.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> category;

        public CategoryService(IRepository<Category> category)
        {
            this.category = category;
        }

        public void Add(Category category)
        {
            this.category.Add(category);
            this.category.SaveChanges();
        }

        public IQueryable<Category> All()
        {
            return category.All();


        }
    }
}
