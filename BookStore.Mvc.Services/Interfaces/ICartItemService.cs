using BookStore.Mvc.DataModel;
using System.Collections.Generic;

namespace BookStore.Mvc.Services.Interfaces
{
    public interface ICartItemService
    {
        void Add(IEnumerable<BookCartItem> items);
    }
}
