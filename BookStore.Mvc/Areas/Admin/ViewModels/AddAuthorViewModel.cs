using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Mvc.Areas.Admin.ViewModels
{
    public class AddAuthorViewModel
    {
        [Display(Name = "Author Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Author Name Requierd")]
        [StringLength(50, ErrorMessage = "Max lenght is 25 and Minimum is 3", MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [StringLength(1000, MinimumLength = 10)]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [DisplayName("Birth")]
        [Required(ErrorMessage = "Year is required")]
        public int Birth { get; set; }

        public HttpPostedFileBase UploadedImage { get; set; }

        [Display(Name = "Country")]
        [Required(ErrorMessage = "Country is required")]
        public string CountryId { get; set; }

        public IEnumerable<SelectListItem> Countries { get; set; }
    }
}