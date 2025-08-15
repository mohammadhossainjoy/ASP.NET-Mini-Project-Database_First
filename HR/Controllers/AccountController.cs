using HR.Models;
using System.Linq;
using System.Web.Mvc;

namespace HR.Controllers
{
    public class AccountController : Controller
    {
        private dbERPEntities db = new dbERPEntities();

        // GET: Login
        public ActionResult Login() => View();

        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            var user = db.Registrations.FirstOrDefault(x => x.Email == email && x.Password == password);

            if (user != null)
            {
                // session flag
                Session["LoggedIn"] = true;
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Error = "Invalid email or password";
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();              
            return RedirectToAction("Login", "Account");  // Back login
        }
    }
}
