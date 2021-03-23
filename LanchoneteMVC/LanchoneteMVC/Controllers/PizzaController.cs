using Data;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace LanchoneteMVC.Controllers
{
    public class PizzaController : Controller
    {
        // GET: Pizza
        public ActionResult Index()
        {
            var lst = this.Crud().Select();
            return View(lst);
        }

        public ActionResult Create()
        {
            return View();
        }

        //Método de envio de dados
        [HttpPost]
        //Evitar que se falsifique o envio de daods para o servidor. Recebe apenas requisições do controlador
        [ValidateAntiForgeryToken]

        public ActionResult Create(Pizza pizza)
        {
            if(ModelState.IsValid)
            {
                this.Crud().Insert(pizza);
                return RedirectToAction("Index");
            }
            return View(pizza);
        }

        public ActionResult Edit(int id)
        {
            var pizza = this.Crud().SelectById(id);
            return View(pizza);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(Pizza pizza)
        {
            if(ModelState.IsValid)
            {
                this.Crud().Update(pizza);
                return RedirectToAction("Index");
            }
            return View(pizza);
        }

        public ActionResult Details(int id)
        {
            var pizza = this.Crud().SelectById(id);
            return View(pizza);
        }

        public ActionResult Delete(int id)
        {
            var pizza = this.Crud().SelectById(id);
            return View(pizza);
        }

        //O ActionName precisa ser o mesmo "Delete", como a orientação a objetos não permite
        //métodos com o mesmo nome e parametros é necessário utilizar esse recurso.
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public ActionResult DeleteConfirm(int id)
        {
            this.Crud().Delete(id);
            return RedirectToAction("Index");
        }

        private IPizzaDB Crud()
        {
            return new PizzaDB();
        }
    }
}