using Evento.Domain.Entity;
using Evento.Infra.EntityConfig;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Evento.Infra.Data
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
            //Database.EnsureCreated();
        }

        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Eventos> Eventos { get; set; }
        public DbSet<Cliente> Cliente { set; get; }
        public DbSet<Dependente> Dependente { get; set; }
        public DbSet<Pais> Pais { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<Inscricao> Inscricao { get; set; }
        public DbSet<InscricaoCliente> InscricaoClientes { get; set; }
        public DbSet<InscricaoEvento> InscricaoEvento { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoriaMap());
            modelBuilder.ApplyConfiguration(new EventoMap());
            modelBuilder.ApplyConfiguration(new ClienteMap());
            modelBuilder.ApplyConfiguration(new DependenteMap());
            modelBuilder.ApplyConfiguration(new InscricaoMap());
            modelBuilder.ApplyConfiguration(new InscricaoClienteMap());
            modelBuilder.ApplyConfiguration(new InscricaoEventoMap());
            modelBuilder.ApplyConfiguration(new PaisMap());
            modelBuilder.ApplyConfiguration(new EstadoMap());
            modelBuilder.ApplyConfiguration(new CidadeMap());

        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }
            }
            return base.SaveChanges();
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Se não estiver configurado no projeto IU pega deginição de chame do json configurado
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(GetStringConectionConfig());

            base.OnConfiguring(optionsBuilder);
        }

        private string GetStringConectionConfig()
        {
            // ambiene  de desenvolvimento
            //string strCon = "Data Source=.\\SQLEXPRESS;Initial Catalog=FazendoArte;Integrated Security=false;User ID=sa;Password=admsql9612;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False";
            string strCon = "Server=(localdb)\\mssqllocaldb;Database=FazendoArte;Trusted_Connection=True;MultipleActiveResultSets=true";


            return strCon;
        }
    }
}
