using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Mvc.DataModel
{
    public partial class ShoppingCart
    {
        private ICollection<BookCart> BookCartsItems;

        public ShoppingCart()
        {
            this.BookCartsItems = new HashSet<BookCart>();
        }

        [Key]
        public int Id { get; set; }



        public ICollection<BookCart> BookCarts
        {
            get { return this.BookCartsItems; }
            set { this.BookCartsItems = value; }
        }
    }
}
