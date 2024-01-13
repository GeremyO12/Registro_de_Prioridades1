using Microsoft.EntityFrameworkCore;
using Registro_de_Prioridades1.Models;

namespace Registro_de_Prioridades1.DAL
{
    public class RegistroContext : DbContext
    {
        public RegistroContext(DbContextOptions<RegistroContext> Options) 
              : base(Options){ }
        public DbSet<Sistemas> Sistemas { get; set;}
    }
}
