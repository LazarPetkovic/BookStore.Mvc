using BookStore.Mvc.DataModel;
using System.Linq;

namespace BookStore.Mvc.Services.Interfaces
{
    public interface IOrderService
    {
        int AddOrder(Order order);

        IQueryable<Order> All();

        void UpdateOrder(Order order);

        IQueryable<Order> GetOrderById(int id);
    }
}
