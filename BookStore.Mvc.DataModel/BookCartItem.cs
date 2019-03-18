using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Mvc.DataModel
{
    public class BookCart
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
