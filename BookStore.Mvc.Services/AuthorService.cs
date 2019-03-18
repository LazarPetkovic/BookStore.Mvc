using BookStore.Mvc.Data.Repositories;
using BookStore.Mvc.DataModel;
using BookStore.Mvc.Services.Interfaces;
using System.Linq;

namespace BookStore.Mvc.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IRepository<Author> author;

        public AuthorService(IRepository<Author> author)
        {
            this.author = author;
        }

        public void Add(Author author)
        {
            this.author.Add(author);
            this.author.SaveChanges();
        }

        public IQueryable<Author> All()
        {
            return this.author
                 .All()
                 .OrderByDescending(x => x.DateAdded);
        }

        public IQueryable<Author> GetAuthorsById(int Id)
        {
            return this.author
                       .All()
                       .Where(x => x.Id == Id);
        }

    }
}
