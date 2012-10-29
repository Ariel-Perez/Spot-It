using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Demo_v2.Models
{
    public class SpotItEntities : DbContext
    {
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Lugar> Lugar { get; set; }
        public DbSet<Lugar_En_Categoria> Lugar_En_Categoria { get; set; }
        public DbSet<Sala> Sala { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}