using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Mvc.ViewModels.Books
{
    public class AllBooksViewModel
    {
        public IList<BooksViewModel> Books { get; set; }

        public int AuthorId { get; set; }

        public SelectList Authors { get; set; }

        public int CategoryId { get; set; }

        public SelectList Categorys { get; set; }

        public string Value { get; set; }

        public SelectList OrderByPrice { get; set; }

        public string SearchString { get; set; }
    }
}