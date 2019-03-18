using BookStore.Mvc.Mappings;
using BookStore.Mvc.Services.Interfaces;
using BookStore.Mvc.ViewModels.Authors;
using BookStore.Mvc.ViewModels.Books;
using BookStore.Mvc.ViewModels.Categories;
using System.IO;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace BookStore.Mvc.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookService book;
        private readonly IAuthorService author;
        private readonly IImageService image;
        private readonly ICategoryService category;

        public BooksController(IBookService book,
                               IAuthorService author,
                               IImageService image,
                               ICategoryService category)
        {
            this.book = book;
            this.author = author;
            this.image = image;
            this.category = category;
        }

        [HttpGet]
        public ActionResult All(int authorId = 0,
                                int categoryId = 0,
                                string searchString = "",
                                string value = "asc")
        {
            return View(GetBooks(authorId, categoryId, searchString, value));
        }

        [HttpPost]
        public ActionResult All(AllBooksViewModel bookModel)
        {
            int authorId = bookModel.AuthorId;
            int categoryId = bookModel.CategoryId;

            return View(GetBooks(authorId,
                                categoryId,
                                bookModel.SearchString,
                                bookModel.Value));
        }

        private AllBooksViewModel GetBooks(int authorId,
                                            int categoryId,
                                            string searchString,
                                            string value)
        {
            var allBooks = this.book
                .All(authorId, categoryId, searchString, value)
                .To<BooksViewModel>()
                .ToList();


            var bookModel = new AllBooksViewModel
            {
                Books = allBooks,
                AuthorId = authorId,
                CategoryId = categoryId,
                Value = value,
                SearchString = searchString,
                OrderByPrice = OrderByPrice(),
                Authors = GetAllAuthors(),
                Categorys = GetAllCategorys()

            };

            return bookModel;
        }


        public ActionResult Details(int id)
        {
            var bookDetails = this.book
                .GetBookById(id)
                .To<BookDetailsViewModel>()
                .FirstOrDefault();

            return View(bookDetails);
        }

        public ActionResult AuthorDetails(int id)
        {
            var detailedAuthors = this.author
                .GetAuthorsById(id)
                .To<AuthorDetailsViewModel>()
                .FirstOrDefault();

            return View(detailedAuthors);
        }

        public SelectList GetAllAuthors()
        {
            var all = this.author
                .All()
                .To<AuthorViewModel>()
                .ToList();

            return new SelectList(all, "Id", "Name");

        }

        public SelectList GetAllCategorys()
        {
            var all = this.category
                .All()
                .To<CategoryViewModel>()
                .ToList();

            return new SelectList(all, "Id", "Name");

        }

        [ChildActionOnly]
        public SelectList OrderByPrice()
        {
            var directions = new SelectList(new[]
                           {
                           new SelectListItem {Text = "Ascending", Value = "asc"},
                           new SelectListItem {Text = "Descending", Value = "desc"},
                       }, "Value", "Text");

            return directions;
        }

        public ActionResult Image(int? id)
        {
            if (id == null)
            {
                var dir = Server.MapPath("/Images/no_image_available.png");
                var path = Path.Combine(dir);

                return File(path, "image/png");

            }

            var image = this.image.GetById(id);
            if (image == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Image not found");
            }

            return File(image.Content, "image/" + image.FileExtension);
        }

    }
}