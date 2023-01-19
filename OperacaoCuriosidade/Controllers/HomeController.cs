using OperacaoCuriosidade.Data;
using OperacaoCuriosidade.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.Services.Description;

namespace OperacaoCuriosidade.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataContext _ctx = new DataContext();

        [HttpGet]
        public ActionResult Index(string returnURL)
        {
            var model = new LoginVM() { ReturnURL = returnURL };
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(LoginVM model)
        {
            var usuario = _ctx.Usuarios.FirstOrDefault(u => u.login_usuario.ToLower() == model.Email.ToLower());

            if (usuario == null)
                ModelState.AddModelError("Email", "E-mail inválido");         
            else
            {
                if (usuario.senha_usuario != model.Senha)
                    ModelState.AddModelError("Senha", "Senha inválida");
            }

            if (ModelState.IsValid)
            {
                FormsAuthentication.SetAuthCookie(model.Email, model.PermanecerLogado);

                if (!string.IsNullOrEmpty(model.ReturnURL) && Url.IsLocalUrl(model.ReturnURL))
                {
                    return Redirect(model.ReturnURL);
                }
                return RedirectToAction("DashBoard", "Home");
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
        public ViewResult Dashboard()
        {
            var colaboradores = _ctx.Colaboradores.ToList();
            var dataAtual = DateTime.Now.Date;
            var dataMes = DateTime.Now.AddDays(-30).Date;
            var totalColaborador = colaboradores.Count();

            ViewBag.TotalColaborador = totalColaborador;
            ViewBag.TotalHoje = colaboradores.Where(w=> w.data_cadastro>=dataAtual).Count(); 
            ViewBag.TotalDias = colaboradores.Where(w => w.data_cadastro >= dataMes).Count();

            return View(colaboradores);
        }
        protected override void Dispose(bool disposing)
        {
            _ctx.Dispose();
        }
    }
}