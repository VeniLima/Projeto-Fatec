using AgoraVaiRecursosHumanos.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AgoraVaiRecursosHumanos.Controllers
{

    public class HomeController : Controller
    {
        private Database1Entities db = new Database1Entities();
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
         public ActionResult Login(String login, String senha)
        {
             if(login == null || login == "")
             {
                 ViewBag.erroLogin = "Erro Login";
             }
             if(senha == null || senha == "")
             {
                 ViewBag.erroSenha = "Erro Senha";
             }
                    
             var vLogin = db.Usuarios.Where(p => p.Login.Trim().Equals(login.Trim())).FirstOrDefault();
             if(vLogin != null)
             {

                 if(Equals(vLogin.Senha.Trim(), senha.Trim()))
                 {


                     Session["Nome"] = vLogin.Login;
                     Session["Perfil"] = vLogin.Id;

                     return RedirectToAction("Guia", "Home");




                 }
                 else
                 {

                    return View();
            }

                }       
            else
            {
  
                return View();

            }

return View();
        }

        public ActionResult Logout()
        {
 
            Session.Clear();
            return RedirectToAction("Login", "Home");

        }


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Error()
        {
            return View();
        }

        public ActionResult Guia()
        {
            return View();
        }

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