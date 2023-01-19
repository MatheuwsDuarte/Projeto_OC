using OperacaoCuriosidade.Data;
using OperacaoCuriosidade.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace OperacaoCuriosidade.Controllers
{
    [Authorize]
    public class ColaboradorController : Controller
    {
        private readonly DataContext _ctx = new DataContext();
        public ActionResult Index()
        {
            var colaborador = _ctx.Colaboradores.ToList();
            return View(colaborador);
        }
        public ActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastro(Colaborador model)
        {
            _ctx.Colaboradores.Add(model);
          
            _ctx.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult Relatorio()
        {
            var colaborador = _ctx.Colaboradores.ToList();
            return View(colaborador);
        }
        public ActionResult Listagem(string Pesquisa = "")
        {
            var q = _ctx.Colaboradores.AsQueryable();
            if (!string.IsNullOrEmpty(Pesquisa))
            q = q.Where(c => c.Nome.Contains(Pesquisa));
            q = q.OrderBy(c => c.Nome);

            return View(q.ToList());
        }
        public ActionResult Edit(int id)
        {
            var colaborador = _ctx.Colaboradores.Find(id);
            _ctx.Colaboradores.Add(colaborador);
            return View(colaborador);
        }

        [HttpPost]
        public ActionResult Edit(Colaborador model)
        {
            _ctx.Entry(model).State=System.Data.Entity.EntityState.Modified;
            _ctx.SaveChanges();
            return RedirectToAction("Listagem");
        }
        public ActionResult Remove(int id)
        {
            var colaborador = _ctx.Colaboradores.Find(id);
            _ctx.Colaboradores.Remove(colaborador);
            _ctx.SaveChanges();
            return RedirectToAction("Listagem");
        }
        protected override void Dispose(bool disposing)
        {
            _ctx.Dispose();
        }
    }
}
