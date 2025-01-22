using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace application.spd.Data
{

    public class AppDbContext : DbContext
    {

        public DbSet<ProjetoEntrega> ProjetoEntregas { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
    }

    public class ProjetoEntrega
    {
        public int Id { get; set; }
        public string NomeDoAluno { get; set; }
        public string UrlDoRepositorio { get; set; }
    }
}
