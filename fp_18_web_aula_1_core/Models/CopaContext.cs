using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fp_web_aula_1_core.Models
{
    public class CopaContext : DbContext
    {
        public CopaContext(DbContextOptions<CopaContext> options) :
            base(options)
        {

        }

        public DbSet<Time> Times { get; set; }
        public DbSet<Jogador> Jogadores { get; set; }
    }
}
