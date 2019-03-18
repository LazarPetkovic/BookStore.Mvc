using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Mvc.DataModel
{
    public class Order
    {

        private ICollection<BookCart> books;

        public Order()
        {
            this.books = new HashSet<BookCart>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public decimal TotalPrice { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime ReceivedDate { get; set; }

        public bool IsApproved { get; set; }

        public object To<T>()
        {
            throw new NotImplementedException();
        }

        public bool IsActive { get; set; }


        public string UserId { get; set; }

        public virtual User User { get; set; }


        public ICollection<BookCart> BookCartsItems
        {
            get { return this.books; }
            set { this.books = value; }
        }
    }
}
