using BookStore.Mvc.Areas.Private.ViewModels;
using BookStore.Mvc.Common;
using BookStore.Mvc.Services.Interfaces;
using BookStore.Mvc.ViewModels.Books;
using System.Linq;
using System.Web.Mvc;

namespace BookStore.Mvc.Areas.Private.Controllers
{
    public class ShoppingCartController : BaseController
    {
        private const string BooksUrl = "/Books/All";

        private IBookService books;

        public ShoppingCartController(IBookService books, IUserService users)
            : base(users)
        {
            this.books = books;
        }

        public ActionResult Index()
        {

            var cart = new ShoppingCartViewModel
            {
                Cart = GetCart(),
                ReturnUrl = BooksUrl
            };

            return View(cart);
        }

        [ChildActionOnly]
        public ActionResult GetCartSummary()
        {
            var cart = new ShoppingCartViewModel
            {
                Cart = GetCart(),
                ReturnUrl = BooksUrl
            };

            return PartialView("_CartSummaryPartial", cart);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddToCart(AddBooksinputModel model, string returnUrl)
        {
            string warningMessage = null;
            if (ModelState.IsValid)
            {
                var book = this.books.GetBookById(model.Id).FirstOrDefault();
                if (book != null)
                {
                    if (book.Quantity >= model.QuantityToOrder)
                    {
                        var cart = this.GetCart();
                        string addBook = cart.AddItem(book, model.QuantityToOrder);
                        if (addBook != null)
                        {
                            warningMessage = addBook;
                        }
                        else
                        {
                            this.books.UpdateBookQuantity(book, (decimal)model.QuantityToOrder);
                            return this.RedirectToAction("Index", new { returnUrl });
                        }
                    }
                    else
                    {
                        warningMessage = WarningMessages.QuantityNotEnough;
                    }
                }
                else
                {
                    warningMessage = WarningMessages.BookNotFound;
                }
            }

            this.TempData["Notification"] = warningMessage;
            return this.RedirectToAction("Details", "Books", new { area = string.Empty, id = model.Id });
        }

        public ActionResult RemoveFromCart(int bookId, string returnUrl)
        {
            var product = this.books.GetBookById(bookId).FirstOrDefault();
            if (product == null)
            {
                this.TempData["Notification"] = WarningMessages.BookNotFound;
            }
            else
            {
                var quantityRemoved = this.GetCart().RemoveItem(bookId);
                this.books.UpdateBookQuantity(product, (quantityRemoved * -1));
            }

            return RedirectToAction("Index", new { returnUrl });
        }
    }
}