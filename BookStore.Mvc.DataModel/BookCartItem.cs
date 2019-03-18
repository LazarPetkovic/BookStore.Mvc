using System.ComponentModel.DataAnnotations;

namespace BookStore.Mvc.DataModel
{
    public class BookCartItem
    {
        [Key]
        public int Id { get; set; }

        public int BookId { get; set; }

        public virtual Book Book { get; set; }

        public decimal Quantity { get; set; }

        public int OrderId { get; set; }

        public virtual Order Order { get; set; }

        public int? ShoppingCartId { get; set; }

        public virtual ShoppingCart ShoppingCart { get; set; }
    }
}
