using AutoMapper;
using BookStore.Mvc.DataModel;
using BookStore.Mvc.Mappings;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookStore.Mvc.ViewModels.Books
{
    public class BooksViewModel : IMapFrom<Book>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public decimal Rating { get; set; }

        public int? ImageId { get; set; }

        public int CategoryId { get; set; }

        public string Category { get; set; }

        public int AuthorId { get; set; }

        public string Author { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Book, BooksViewModel>()
                            .ForMember(x => x.Author, a => a.MapFrom(x => x.Author.Name))
                            .ForMember(x => x.Category, a => a.MapFrom(x => x.Category.Name));
        }
    }
}