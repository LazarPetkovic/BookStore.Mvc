using BookStore.Mvc.Data.Repositories;
using BookStore.Mvc.DataModel;
using BookStore.Mvc.Services.Interfaces;
using System.Linq;

namespace BookStore.Mvc.Services
{
    public class BookService : IBookService
    {
        private readonly IRepository<Book> book;

        public BookService(IRepository<Book> book)
        {
            this.book = book;
        }

        public void Add(Book book)
        {
            this.book.Add(book);
            this.book.SaveChanges();
        }

        public IQueryable<Book> All()
        {
            return this.book
                 .All()
                 .OrderByDescending(x => x.DateAdded);

        }

        public IQueryable<Book> All(int authorId, int categoryId, string searchString, string orderByPrice)
        {
            var books = this.book
                .All()
                .Where(x => x.AuthorId != 0 ? x.AuthorId == authorId : x.AuthorId == x.AuthorId)
                .Where(x => x.CategoryId != 0 ? x.CategoryId == categoryId : x.CategoryId == x.CategoryId)

                .Where(x => string.IsNullOrEmpty(searchString) || x.Name.Contains(searchString));

            if (orderByPrice == "desc")
            {
                return books.OrderByDescending(x => x.Price);
            }

            return books.OrderBy(x => x.Price);
        }

        public IQueryable<Book> GetBookById(int Id)
        {
            return this.book
                       .All()
                       .Where(x => x.Id == Id);
        }
        public void UpdateBookQuantity(Book book, decimal quantity)
        {
            book.Quantity -= quantity;
            this.book.SaveChanges();
        }

        public int CountBooks(string searchString)
        {
            return this.book
                .All()
                .Where(x => string.IsNullOrEmpty(searchString) || x.Name.Contains(searchString))
                .Count();
        }

        public int CountBookByAuthor(int authorId, string searchString)
        {
            return this.book
               .All()
               .Where(x => x.AuthorId == authorId)
               .Where(x => string.IsNullOrEmpty(searchString) || x.Name.Contains(searchString))
               .Count();
        }
    }
}
