using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Mvc.DataModel
{
    public class Book
    {
        private ICollection<BookCartItem> bookCartItems;

        public Book()
        {
            this.bookCartItems = new HashSet<BookCartItem>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        [StringLength(1000, MinimumLength = 10)]
        public string Description { get; set; }

        public decimal Price { get; set; }

        public decimal Quantity { get; set; }

        public decimal Rating { get; set; }

        public DateTime DateAdded { get; set; }

        public int? ImageId { get; set; }

        public virtual Image Image { get; set; }

        public int AuthorId { get; set; }

        public virtual Author Author { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<BookCartItem> BookCartItems
        {
            get { return this.bookCartItems; }
            set { this.bookCartItems = value; }
        }
    }
}
