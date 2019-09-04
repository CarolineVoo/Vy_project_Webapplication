using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Gruppeoppgave_1.Models;
using Losning_pizza_oppgave.Models;

namespace Losning_pizza_oppgave
{
    public class DB
    {
        public bool settInnBestillng(Pizza bestiltPizza)
        {
            using (var db = new KundeContext())
            {
                var bestilling = new Bestilling()
                {
                    Antall = bestiltPizza.antall,
                    PizzaType = bestiltPizza.pizzaType,
                    TykkBunn = bestiltPizza.tykkelse
                };

                Kunde funnetKunde = db.Kunder.FirstOrDefault(k => k.Navn == bestiltPizza.navn);

                if (funnetKunde == null)
                {
                    // opprett kunden
                    var kunde = new Kunde
                    {
                        Navn = bestiltPizza.navn,
                        Adresse = bestiltPizza.adresse,
                        Telefonnr = bestiltPizza.telefonnr,
                    };
                    // legg bestillingen inn i kunden
                    kunde.Bestillinger = new List<Bestilling>();
                    kunde.Bestillinger.Add(bestilling);
                    try
                    {
                        db.Kunder.Add(kunde);
                        db.SaveChanges();
                        return true;
                    }
                    catch (Exception feil)
                    {

                        return false;
                    }
                }
                else
                {
                    try
                    {
                        funnetKunde.Bestillinger.Add(bestilling);
                        db.SaveChanges();
                        return true;
                    }
                    catch (Exception feil)
                    {
                        return false;
                    }
                }
            }
        }

        public List<Pizza> listAlleBestillnger()
        {
            var db = new KundeContext();

            // dette EF-kallet er endret til en JOIN i forhold til løsningen i forrige oppgave!
            List<Pizza> alleBestillinger = db.Kunder.Join(db.Bestillinger,
                                                   k => k.KId,
                                                   b => b.KId,
                                                   (k, b) => new Pizza
                                                   {
                                                       Bid = b.BId,
                                                       navn = k.Navn,
                                                       adresse = k.Adresse,
                                                       telefonnr = k.Telefonnr,
                                                       pizzaType = b.PizzaType,
                                                       tykkelse = b.TykkBunn,
                                                       antall = b.Antall
                                                   }).ToList();

            return alleBestillinger;
        }
        public bool slettBestilling(int Bid)
        {
            // vil ikke slette kunden selv om det ikke er noen flere bestillinger på denne
            using (var db = new KundeContext())
            {
                // finn bestillingen
                Bestilling enBestilling = db.Bestillinger.Find(Bid);
                if (enBestilling == null) // fant ikke bestillingen
                {
                    return false;
                }
                // slett bestillingen 
                try
                {
                    db.Bestillinger.Remove(enBestilling);
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}