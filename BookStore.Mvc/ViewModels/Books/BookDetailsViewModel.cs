using AutoMapper;
using BookStore.Mvc.DataModel;
using BookStore.Mvc.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Mvc.ViewModels.Books
{
    public class BookDetailsViewModel : IMapFrom<Book>, IHaveCustomMappings
    {
        public int Id { get; set; }


        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public decimal Quantity { get; set; }

        public decimal Rating { get; set; }

        public DateTime DateAdded { get; set; }

        public int? ImageId { get; set; }


        public string Author { get; set; }

        public string Category { get; set; }


        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Book, BookDetailsViewModel>()
                .ForMember(x => x.Author, a => a.MapFrom(x => x.Author.Name))
                .ForMember(x => x.Category, a => a.MapFrom(x => x.Category.Name));
        }
    }
}