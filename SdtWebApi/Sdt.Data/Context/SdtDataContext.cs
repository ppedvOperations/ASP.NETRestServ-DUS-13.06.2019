using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sdt.Bo.Entities;

namespace Sdt.Data.Context
{
    public class SdtDataContext : DbContext
    {
        public SdtDataContext() : base("DefaultConnection")
        {
            Database.Log = c => Debug.WriteLine(c);

            Database.SetInitializer(new SdtSeedData());
        }

        public DbSet<Autor> Autoren { get; set; }
        public DbSet<Spruch> Sprueche { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Entfernen von Pluralisierung
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
