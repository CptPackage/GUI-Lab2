using LibraryMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;

namespace LibraryMVC.Controllers
{
    public class LoginController : Controller
    {

        private static UsersRepository userRepo = UsersRepository.getInstance();

        enum AUTH_STATUS {
        NO_AUTH = 0,
        FAILED = -1,
        SUCCESS = 1
        };

        // GET: LoginController
        public ActionResult Index()
        {
            return View();
        }

        // POST: LoginController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(IFormCollection collection)
        {
            StringValues username = "";
            StringValues password;
            bool containsUsername = collection.TryGetValue("username", out username);
            bool containsPassword = collection.TryGetValue("password", out password);

            if (!containsUsername || !containsPassword) {
                ViewBag.Message = "Please enter username and Password!";
                ViewBag.Status = -1;
            }

            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LoginController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LoginController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LoginController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LoginController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
