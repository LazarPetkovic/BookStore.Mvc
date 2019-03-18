using BookStore.Mvc.DataModel;
using System.Linq;

namespace BookStore.Mvc.Services.Interfaces
{
    public interface IBookService
    {
        int CountBooks(string searchString);

        int CountBookByAuthor(int authorId, string searchString);

        IQueryable<Book> All();

        IQueryable<Book> All(int authorId, int categoryId, string searchString, string orderByPrice);

        IQueryable<Book> GetBookById(int id);

        void UpdateBookQuantity(Book book, decimal quantity);

        void Add(Book book);
    }
}
