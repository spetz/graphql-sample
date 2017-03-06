using Microsoft.AspNetCore.Mvc;

namespace Graphql.Api.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}