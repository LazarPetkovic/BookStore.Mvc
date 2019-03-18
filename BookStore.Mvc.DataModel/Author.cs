using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Mvc.DataModel
{
    public class Author
    {
        private ICollection<Book> books;

        public Author()
        {
            this.books = new HashSet<Book>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        [StringLength(5000, MinimumLength = 10)]
        public string Description { get; set; }

        public int Birth { get; set; }

        public DateTime DateAdded { get; set; }

        public int? ImageId { get; set; }

        public virtual Image Image { get; set; }

        public int CountryId { get; set; }

        public virtual Country Country { get; set; }


        public virtual ICollection<Book> Books
        {
            get { return this.books; }
            set { this.books = value; }
        }
    }
}
