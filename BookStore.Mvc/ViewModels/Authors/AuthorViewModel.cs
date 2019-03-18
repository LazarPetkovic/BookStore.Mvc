using AutoMapper;
using BookStore.Mvc.DataModel;
using BookStore.Mvc.Mappings;

namespace BookStore.Mvc.ViewModels.Authors
{
    public class AuthorViewModel : IMapFrom<Author>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Country { get; set; }



        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Author, AuthorViewModel>()
                .ForMember(x => x.Country, opt => opt.MapFrom(x => x.Country.Name));

        }
    }
}