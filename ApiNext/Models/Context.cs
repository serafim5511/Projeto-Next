using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNext.Models
{
    public class Context:DbContext
    {
        public DbSet<DadosPessoais> DadosPessoais { get; set; }
        public DbSet<EnderecoResidencial> EnderecoResidencial { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=ProjetoNext");
            optionsBuilder.UseSqlServer(@"Server=homologue.database.windows.net;Database=ProjetoJunior;User ID=adm; Password=pZPZQsGdD5j!W2s;");

        }

    }
}
