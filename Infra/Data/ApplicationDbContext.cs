using Infra.Models.Table;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            this.Database.EnsureCreated();
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    string connectionString = ConnectionBuilder.GetConnectionString();

        //    optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

        //    base.OnConfiguring(optionsBuilder);
        //}

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Venda> Venda { get; set; }
        public DbSet<ProdutoVenda> ProdutoVenda { get; set; }
    }
}
