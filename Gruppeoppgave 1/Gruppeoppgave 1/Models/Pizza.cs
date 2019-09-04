using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Losning_pizza_oppgave.Models
{
    public class Pizza
    {
        public int Bid { get; set; }   // legger på denne for å få mulighet for å slette bestillingene
        public string pizzaType { get; set; }
        public string tykkelse { get; set; }
        public int antall { get; set; }
        public string navn { get; set; }
        public string adresse { get; set; }
        public string telefonnr { get; set; }
    }
}