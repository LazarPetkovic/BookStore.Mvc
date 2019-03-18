using System.Collections.Generic;

namespace BookStore.Mvc.ViewModels.Authors
{
    public class AllAuthorsViewModel
    {
        public IEnumerable<AuthorViewModel> Authors { get; set; }

        public string Order { get; set; }
    }
}