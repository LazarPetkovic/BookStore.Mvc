using BookStore.Mvc.Areas.Admin.ViewModels;
using BookStore.Mvc.DataModel;
using BookStore.Mvc.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace BookStore.Mvc.Areas.Admin.Controllers
{
    public class AuthorAdminController : Controller
    {
        private readonly IAuthorService author;
        private readonly ICountryService country;

        public AuthorAdminController(IAuthorService author,
                                     ICountryService country)
        {
            this.author = author;
            this.country = country;
        }

        [HttpGet]
        public ActionResult AddAuthor()
        {
            var model = new AddAuthorViewModel
            {
                Countries = this.GetCountries()
            };

            return View(model);
        }


        public ActionResult AddAuthor(AddAuthorViewModel model)
        {
            if (ModelState.IsValid)
            {
                var newAuthor = new Author
                {
                    Name = model.Name,
                    Description = model.Description,
                    Birth = model.Birth,
                    CountryId = int.Parse(model.CountryId)
                };

                this.author.Add(newAuthor);
            }
            return Redirect("/");
        }

        private IEnumerable<SelectListItem> GetCountries()
        {
            var country = this.country
                .All()
                .Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                })
                .ToList();

            return country;

        }
    }
}