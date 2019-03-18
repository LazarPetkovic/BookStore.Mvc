using BookStore.Mvc.Data.Repositories;
using BookStore.Mvc.DataModel;
using BookStore.Mvc.Services.Interfaces;
using System.Linq;

namespace BookStore.Mvc.Services
{
    public class CountryService : ICountryService
    {
        private readonly IRepository<Country> countries;

        public CountryService(IRepository<Country> countries)
        {
            this.countries = countries;
        }

        public IQueryable<Country> All()
        {
            return this.countries.All();
        }
    }
}
