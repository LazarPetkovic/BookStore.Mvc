using BookStore.Mvc.DataModel;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace BookStore.Mvc.Data
{
    public interface IBookStoreDbContext
    {
        IDbSet<User> Users { get; set; }

        IDbSet<Author> Authors { get; set; }

        IDbSet<Book> Books { get; set; }

        IDbSet<BookCartItem> BookCarts { get; set; }

        IDbSet<Country> Countrys { get; set; }

        IDbSet<Category> Categorys { get; set; }

        IDbSet<Image> Images { get; set; }

        IDbSet<Order> Orders { get; set; }

        IDbSet<ShoppingCart> ShoppingCarts { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        int SaveChanges();

        void Dispose();
    }
}
