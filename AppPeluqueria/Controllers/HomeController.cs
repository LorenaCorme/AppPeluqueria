using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppPeluqueria.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AccesoAPP()
        {
            return View();
        }

        public ActionResult Bienvenido()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult AccesoAPP(LoginModel login)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View();
        //    }

        //    bool loginOK = dao.login(login.usuario, login.clave);
        //    if (loginOK)
        //    {
        //        return RedirectToAction("Index");
        //    }
        //}

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}