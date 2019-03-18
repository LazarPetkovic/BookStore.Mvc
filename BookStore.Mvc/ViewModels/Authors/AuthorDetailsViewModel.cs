using AutoMapper;
using BookStore.Mvc.DataModel;
using BookStore.Mvc.Mappings;
using System;

namespace BookStore.Mvc.ViewModels.Authors
{
    public class AuthorDetailsViewModel : IMapFrom<Author>, IHaveCustomMappings
    {
        public int Id { get; set; }


        public string Name { get; set; }


        public string Description { get; set; }

        public int Birth { get; set; }

        public DateTime DateAdded { get; set; }

        public int? ImageId { get; set; }

        public string Country { get; set; }

        public string Books { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Author, AuthorDetailsViewModel>()
                .ForMember(x => x.Country, a => a.MapFrom(x => x.Country.Name))
                .ForMember(p => p.Books, opt => opt.MapFrom(p => p.Books.Count));

        }
    }
}