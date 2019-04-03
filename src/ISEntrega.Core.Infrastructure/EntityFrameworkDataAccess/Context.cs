namespace ISEntrega.Core.Infrastructure.EntityFrameworkDataAccess
{
    using Microsoft.EntityFrameworkCore;
    using ISEntrega.Core.EntityFrameworkDataAccess.Entities;
    using System.Linq;

    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options)
        {
            this.Database.SetCommandTimeout(300);
        }

        #region IUnitOfWork Members
        private bool HasChanges
        {
            get
            {
                return this.ChangeTracker.Entries().Any(
                  e => e.State == EntityState.Added || e.State == EntityState.Modified || e.State == EntityState.Deleted);
            }
        }

        public void Commit()
        {
            try
            {
                if (HasChanges)
                    this.SaveChanges();
            }            
            catch (DbUpdateException updateException)
            {
                throw;
            }
        }       
        #endregion

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Matriz> Matrizes { get; set; }
        public DbSet<Ponto> Pontos { get; set; }
        public DbSet<InformacaoCobranca> InformacoesCobranca { get; set; }
        public DbSet<EmpresaFaturamento> EmpresasFaturamento { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>().HasKey(o => o.OID);
            modelBuilder.Entity<Cliente>().ToTable(nameof(Cliente));

            modelBuilder.Entity<Matriz>().HasKey(o => o.Oid);
            modelBuilder.Entity<Matriz>().ToTable(nameof(Matriz));

            modelBuilder.Entity<Ponto>().HasKey(o => o.Oid);
            modelBuilder.Entity<Ponto>().ToTable(nameof(Ponto));

            modelBuilder.Entity<InformacaoCobranca>().HasKey(o => o.Oid);
            modelBuilder.Entity<InformacaoCobranca>().ToTable(nameof(InformacaoCobranca));

            modelBuilder.Entity<EmpresaFaturamento>().HasKey(o => o.Oid);
            modelBuilder.Entity<EmpresaFaturamento>().ToTable(nameof(EmpresaFaturamento));
        }
    }
}
