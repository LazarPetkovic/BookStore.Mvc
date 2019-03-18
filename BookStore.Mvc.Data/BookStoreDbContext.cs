using BookStore.Mvc.DataModel;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace BookStore.Mvc.Data
{
    public class BookStoreDbContext : IdentityDbContext<User>, IBookStoreDbContext
    {
        public BookStoreDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static BookStoreDbContext Create()
        {
            return new BookStoreDbContext();
        }

        public virtual IDbSet<Author> Authors { get; set; }

        public virtual IDbSet<Book> Books { get; set; }

        public virtual IDbSet<BookCartItem> BookCarts { get; set; }

        public virtual IDbSet<Country> Countrys { get; set; }

        public virtual IDbSet<Category> Categorys { get; set; }

        public virtual IDbSet<Image> Images { get; set; }

        public virtual IDbSet<Order> Orders { get; set; }

        public virtual IDbSet<ShoppingCart> ShoppingCarts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
