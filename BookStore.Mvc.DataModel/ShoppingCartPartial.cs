using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Mvc.DataModel
{
    public partial class ShoppingCart
    {
        public string AddItem(Book book, decimal quantity)
        {
            var item = this.BookCarts
                .Where(p => p.Book.Id == book.Id)
                .FirstOrDefault();

            if (item == null)
            {
                var cartItem = new BookCart
                {
                    Book = book,
                    Quantity = quantity
                };

                this.BookCarts.Add(cartItem);
            }
            else
            {
                return "You have already ordered this product!";
            }

            return null;
        }

        public decimal RemoveItem(int bookId)
        {
            var item = this.BookCarts
                .Where(i => i.Book.Id == bookId)
                .FirstOrDefault();

            this.BookCarts.Remove(item);

            return item.Quantity;
        }

        public decimal GetCartTotal()
        {
            var total = this.BookCarts.Sum(i => i.Quantity * i.Book.Price);
            return total;
        }

        public void Clear()
        {
            this.BookCarts.Clear();
        }
    }
}
