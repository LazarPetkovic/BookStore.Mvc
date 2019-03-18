using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Mvc.Areas.Admin.ViewModels
{
    public class AddBookViewModel
    {
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        [StringLength(1000, MinimumLength = 10)]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal Price { get; set; }

        [Required]
        [Range(1, 5)]
        public decimal Rating { get; set; }

        [Required(ErrorMessage = "Quantity should be a positive number")]
        [Range(0.01, double.MaxValue)]
        public decimal Quantity { get; set; }

        public HttpPostedFileBase UploadedImage { get; set; }

        [Display(Name = "Author")]
        [Required(ErrorMessage = "Author is required")]
        public string AuthorId { get; set; }

        [Display(Name = "Category")]
        [Required(ErrorMessage = "Category is required")]
        public string CategoryId { get; set; }

        public IEnumerable<SelectListItem> Authors { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; }
    }
}