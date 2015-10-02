using System.Web.Mvc;

namespace greenhousebanner.Controllers
{
    [RoutePrefix("Admin")]
    public class AdminController : Controller
    {
        //
        // GET: /Admin/
        [Route]
        public ActionResult Index()
        {
            return RedirectToAction("Index","Banner");
        }
	}
}