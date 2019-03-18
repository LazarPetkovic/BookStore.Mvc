using System.Web.Mvc;

namespace BookStore.Mvc.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Error400()
        {
            return View();
        }

        public ActionResult Error404()
        {
            return View();
        }

        public ActionResult Error500()
        {
            return View();
        }
    }
}