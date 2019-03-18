using BookStore.Mvc.Areas.Private.ViewModels;
using BookStore.Mvc.DataModel;
using BookStore.Mvc.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace BookStore.Mvc.Areas.Private.Controllers
{
    [Authorize]
    public class OrdersController : BaseController
    {

        private IOrderService orders;
        private ICartItemService items;

        public OrdersController(IUserService users,
                                IOrderService orders,
                                ICartItemService items)
                                : base(users)
        {
            this.orders = orders;
            this.items = items;
        }

        [HttpGet]
        public ActionResult MakeOrder()
        {
            var user = this.CurrentUser;
            var model = new MakeAnOrderViewModel
            {
                TotalPrice = GetCart().GetCartTotal(),
                OrderDate = DateTime.UtcNow.ToShortDateString(),
                CreditLimit = (decimal)user.CreditLimit,

            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MakeOrder(MakeAnOrderViewModel order)
        {
            if (ModelState.IsValid)
            {
                var cartBooks = GetCart().BookCarts;
                var newOrder = new Order()
                {
                    OrderDate = Convert.ToDateTime(order.OrderDate),
                    ReceivedDate = Convert.ToDateTime(order.ReceivedDate),
                    TotalPrice = order.TotalPrice,
                    UserId = this.CurrentUser.Id,
                    IsActive = true,
                    IsApproved = false
                };


                int id = this.orders.AddOrder(newOrder);
                var orderItems = new List<BookCartItem>();
                foreach (var item in cartBooks)
                {
                    item.BookId = item.Book.Id;
                    item.Book = null;
                    item.OrderId = id;
                    orderItems.Add(item);
                }

                this.items.Add(orderItems);
                GetCart().Clear();

                return Redirect("/");
            }


            return View(order);
        }


    }
}