using Apartmani.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Apartmani.Web.Areas.Admin.Models
{
    public class VisitorsManagerDbContext : DbContext
    {
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Visitor> Visitors { get; set; }
        public DbSet<VisitorGroup> VisitorGroups { get; set; }
        public DbSet<Prices> Prices { get; set; }
        public DbSet<Inquiry> Inquiries { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)

        {

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

        }
    }
}