using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Mvc.DataModel
{
    public partial class ShoppingCart
    {
        private ICollection<BookCartItem> BookCartsItems;

        public ShoppingCart()
        {
            this.BookCartsItems = new HashSet<BookCartItem>();
        }

        [Key]
        public int Id { get; set; }



        public ICollection<BookCartItem> BookCarts
        {
            get { return this.BookCartsItems; }
            set { this.BookCartsItems = value; }
        }
    }
}
