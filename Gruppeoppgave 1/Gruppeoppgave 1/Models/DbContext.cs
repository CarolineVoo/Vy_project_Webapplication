using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Gruppeoppgave_1.Models
{
    public class Kunde
    {
        [Key]
        public int KId { get; set; }
        public string Navn { get; set; }
        public string Adresse { get; set; }
        public string Telefonnr { get; set; }

        public virtual List<Bestilling> Bestillinger { get; set; }
    }
    public class Bestilling
    {
        [Key]
        public int BId { get; set; }
        public string PizzaType { get; set; }
        public string TykkBunn { get; set; }
        public int Antall { get; set; }
        public int KId { get; set; }

        public virtual Kunde Kunde { get; set; }
    }

    public class KundeContext : DbContext
    {
        public KundeContext() : base("name=Pizza")
        {
            Database.CreateIfNotExists();
        }

        public DbSet<Kunde> Kunder { get; set; }
        public DbSet<Bestilling> Bestillinger { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}