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
             
             //verificando se o usuario exeite no banco de dados
             //expressão lambda com Linq            
             var vLogin = db.Usuarios.Where(p => p.Login.Trim().Equals(login.Trim())).FirstOrDefault();
             if(vLogin != null)
             {
                 //chegando nesse ponto, o usuario existe
                 //verificando então se a senha confere
                 if(Equals(vLogin.Senha.Trim(), senha.Trim()))
                 {
                     //chegando aqui significa que login e senha são validos
                     //criar uma sessão para o navegador

                     Session["Nome"] = "Logado";
                     Session["Perfil"] = "Admin";

                     return RedirectToAction("Guia", "Home");




                 }
                 else
                 {
                     /*Escreve na tela a mensagem de erro informada*/
                       ViewBag.erroSenha = "Senha informada Inválida!!!";
                    /*Retorna a tela de login*/
                    return View();
            }

                }       
            else
            {
    /*Escreve na tela a mensagem de erro informada*/
    ViewBag.erroLogin = "Nome de Usuário informado inválido!!!";
    /*Retorna a tela de login*/
    return View();

            }

return View();
        }

        public ActionResult Logout()
        {
            //chegando aqui, devemos destruir as sessões
            //redirecionar para a pagina de login
            Session.Clear();
            return RedirectToAction("Login", "Home");

        }


        public ActionResult Index()
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