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
        public DbSet<Autoridad> Autoridad { get; set; }
        public DbSet<Asiste> Asiste { get; set; }
        public DbSet<Badge> Badge { get; set; }
        public DbSet<Comentario> Comentario { get; set; }
        public DbSet<Complejo> Complejo { get; set; }
        public DbSet<Construccion> Construccion { get; set; }
        public DbSet<Departamento> Departamento { get; set; }
        public DbSet<Evento>  Evento { get; set; }
        public DbSet<Facultad> Facultad { get; set; }
        public DbSet<Horarios> Horarios { get; set; }
        public DbSet<Mapa> Mapa { get; set; }
        public DbSet<Premio> Premio { get; set; }
        public DbSet<Punto> Punto { get; set; }
        public DbSet<Sala> Sala { get; set; }
        public DbSet<TrabajaEn> TrabajaEn { get; set; }
        public DbSet<Zona> Zona { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}