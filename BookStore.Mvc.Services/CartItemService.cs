using BookStore.Mvc.Data.Repositories;
using BookStore.Mvc.DataModel;
using BookStore.Mvc.Services.Interfaces;
using System.Collections.Generic;

namespace BookStore.Mvc.Services
{
    public class CartItemService : ICartItemService
    {
        private readonly IRepository<BookCartItem> items;

        public CartItemService(IRepository<BookCartItem> items)
        {
            this.items = items;
        }

        public void Add(IEnumerable<BookCartItem> items)
        {
            foreach (var item in items)
            {
                this.items.Add(item);
            }
            this.items.SaveChanges();
        }
    }
}
