using BookStore.Mvc.DataModel;
using System.Linq;

namespace BookStore.Mvc.Services.Interfaces
{
    public interface ICountryService
    {
        IQueryable<Country> All();
    }
}
