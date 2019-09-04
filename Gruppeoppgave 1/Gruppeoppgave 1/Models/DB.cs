using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Gruppeoppgave_1.Models
{
    public class DB : DbContext
    {
        public DB()
            : base("name=Bilett")
        {
            Database.CreateIfNotExists();
        }
        public DbSet<Kunde> Kunder { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }

    public class Kunde
    {
        public int Id { get; set; }
        public string Navn { get; set; }
        public string Adresse { get; set; }
    }

}