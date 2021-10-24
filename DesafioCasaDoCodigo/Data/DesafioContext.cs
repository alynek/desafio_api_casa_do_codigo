using DesafioCasaDoCodigo.Controllers;
using Microsoft.EntityFrameworkCore;

namespace DesafioCasaDoCodigo.Data
{
    public class DesafioContext : DbContext
    {
        public DesafioContext(DbContextOptions<DesafioContext> opt) : base(opt){}

        public DbSet<Autor> Autores { get; set; }
    }
}
