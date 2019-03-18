using BookStore.Mvc.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Mvc.Services.Interfaces
{
    public interface IAuthorService
    {
        IQueryable<Author> All();

        IQueryable<Author> GetAuthorsById(int id);

        void Add(Author author);


    }
}
