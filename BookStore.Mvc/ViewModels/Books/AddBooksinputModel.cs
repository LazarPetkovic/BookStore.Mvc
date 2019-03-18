using System;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Mvc.ViewModels.Books
{
    public class AddBooksinputModel
    {
        public int Id { get; set; }

        //[Required]
        [UIHint("Decimal")]
        [Range(0.1, Double.MaxValue)]
        public decimal QuantityToOrder { get; set; }
    }
}