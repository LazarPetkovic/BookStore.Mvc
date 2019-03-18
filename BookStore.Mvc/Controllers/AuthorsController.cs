using BookStore.Mvc.Mappings;
using BookStore.Mvc.Services.Interfaces;
using BookStore.Mvc.ViewModels.Authors;
using System.Linq;
using System.Web.Mvc;

namespace BookStore.Mvc.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly IAuthorService authors;

        public AuthorsController(IAuthorService authors)
        {
            this.authors = authors;
        }

        public ActionResult All(string sortOrder)
        {
            ViewBag.NameSortParm = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.CountrySortParm = sortOrder == "Country" ? "country_desc" : "Country";

            var authors = this.authors.All();

            switch (sortOrder)
            {
                case "name_desc":
                    authors = authors.OrderByDescending(p => p.Name);
                    break;
                case "Country":
                    authors = authors.OrderBy(p => p.Country.Name);
                    break;
                case "country_desc":
                    authors = authors.OrderByDescending(p => p.Country.Name);
                    break;
                default:
                    authors = authors.OrderBy(p => p.Name);
                    break;
            }

            var AllAuthors = authors
                            .To<AuthorViewModel>()
                            .ToList();

            var model = new AllAuthorsViewModel
            {
                Authors = AllAuthors,
                Order = sortOrder
            };

            return View(model);
        }
    }
}