using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Projeto.Data.Mappings;
using Projeto.Data.Entities;

namespace Projeto.Data.Contexts
{
    //classe utilizada para acessar o banco de dados..
    //REGRA 1) Herdar DbContext
    public class DataContext : DbContext
    {
        //ctor + 2x[tab]
        public DataContext(DbContextOptions<DataContext> options)
            : base(options) //enviando para a superclasse
        {

        }

        //REGRA 2) Sobrescrita (OVERRIDE) do método OnModelCreating..
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //adicionar cada classe de mapeamento criada para EntityFramework
            modelBuilder.ApplyConfiguration(new ProdutoMap());
        }

        //REGRA 3) Adicionar cada classe de entidade do projeto
        //utilizando um tipo do EntityFramework chamado DbSet
        public DbSet<Produto> Produto { get; set; }
    }
}
