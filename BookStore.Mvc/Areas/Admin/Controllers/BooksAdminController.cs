using BookStore.Mvc.Areas.Admin.ViewModels;
using BookStore.Mvc.DataModel;
using BookStore.Mvc.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace BookStore.Mvc.Areas.Admin.Controllers
{
    public class BooksAdminController : Controller
    {
        private readonly IBookService book;
        private readonly IAuthorService author;
        private readonly ICategoryService category;

        public BooksAdminController(IBookService book,
                                    IAuthorService author,
                                    ICategoryService category)
        {
            this.book = book;
            this.author = author;
            this.category = category;
        }

        [HttpGet]
        public ActionResult AddBook()
        {
            var model = new AddBookViewModel
            {
                Authors = GetAllAuthors(),
                Categories = GetAllCategorys()
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult AddBook(AddBookViewModel model)
        {
            if (ModelState.IsValid)
            {
                var newBook = new Book
                {
                    Name = model.Name,
                    Description = model.Description,
                    DateAdded = DateTime.UtcNow,
                    Price = model.Price,
                    Rating = model.Rating,
                    Quantity = model.Quantity,
                    AuthorId = int.Parse(model.AuthorId),
                    CategoryId = int.Parse(model.CategoryId)
                };

                if (model.UploadedImage != null)
                {
                    using (var memory = new MemoryStream())
                    {
                        model.UploadedImage.InputStream.CopyTo(memory);
                        var content = memory.GetBuffer();

                        var image = new Image
                        {
                            Content = content,
                            FileExtension = model.UploadedImage.FileName.Split(new[] { '.' }).Last()
                        };

                        newBook.Image = image;
                    }
                }
                this.book.Add(newBook);

                return Redirect("/");
            }

            return View();
        }


        private IEnumerable<SelectListItem> GetAllAuthors()
        {
            var author = this.author
                .All()
                .Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                })
                .ToList();

            return author;

        }

        private IEnumerable<SelectListItem> GetAllCategorys()
        {
            var category = this.category
                .All()
                .Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                })
                .ToList();

            return category;

        }
    }
}