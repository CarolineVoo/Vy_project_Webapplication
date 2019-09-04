using Losning_pizza_oppgave;
using Losning_pizza_oppgave.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gruppeoppgave_1.Controllers
{
    public class PizzaController : Controller
    {
        public ActionResult Index()
        {
            var db = new DB();
            List<Pizza> alleBestillinger = db.listAlleBestillnger();
            return View(alleBestillinger);
        }

        public ActionResult Bestilling()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Bestilling(Pizza innPizza)
        {
            var db = new DB();
            if (db.settInnBestillng(innPizza))
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Slett(int Bid)
        {
            var db = new DB();
            if (!db.slettBestilling(Bid))
            {
                // feilhåndtering bør gjøres her, er ikke implementert ennå
            }
            return RedirectToAction("Index");
        }
    }
}