using AutoMapper;
using BookStore.Mvc.DataModel;
using BookStore.Mvc.Mappings;

namespace BookStore.Mvc.ViewModels.Categories
{
    public class CategoryViewModel : IMapFrom<Category>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Category, CategoryViewModel>();


        }
    }
}