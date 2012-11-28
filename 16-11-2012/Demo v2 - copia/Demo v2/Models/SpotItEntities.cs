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
        public DbSet<Sala> Sala { get; set; }
        public DbSet<Facultad> Facultad { get; set; }
        public DbSet<Departamento> Departamento { get; set; }
        public DbSet<Autoridad> Autoridad { get; set; }
        public DbSet<Horario> Horario { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            Configuration.ProxyCreationEnabled = true;
            Configuration.LazyLoadingEnabled = true;

            modelBuilder.Entity<Categoria>().HasMany(x => x.Lugar).WithMany(x => x.Categoria)
            .Map(m =>
            {
                m.ToTable("LugarCategoria"); // Relationship table name
                m.MapLeftKey("CategoriaId");
                m.MapRightKey("LugarId");
            });

            modelBuilder.Entity<Punto>().HasKey(obj => new { obj.LugarId, obj.NumPunto });
            modelBuilder.Entity<Comentario>().HasKey(obj => new { obj.LugarId, obj.Numero });
            modelBuilder.Entity<Departamento>().HasKey(obj => new { obj.DepartamentoId, obj.FacultadId });
            modelBuilder.Entity<TrabajaEn>().HasKey(obj => new { obj.FacultadId, obj.AutoridadId, obj.DepartamentoId });
            modelBuilder.Entity<Sala>().HasKey(obj => new { obj.LugarId });
            modelBuilder.Entity<Horario>().HasKey(obj => new { obj.LugarId, obj.Modulo, obj.Dia });

            modelBuilder.Entity<Lugar>().HasOptional<Lugar>(l => l.LugarContenedor).WithMany().HasForeignKey(l => l.LugarId);
        }
    }
}