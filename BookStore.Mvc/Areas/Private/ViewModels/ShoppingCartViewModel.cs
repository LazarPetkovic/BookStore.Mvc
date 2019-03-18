using BookStore.Mvc.DataModel;

namespace BookStore.Mvc.Areas.Private.ViewModels
{
    public class ShoppingCartViewModel
    {
        public ShoppingCart Cart { get; set; }

        public string ReturnUrl { get; set; }
    }
}