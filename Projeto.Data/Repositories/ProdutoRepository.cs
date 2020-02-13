using Projeto.Data.Contracts;
using Projeto.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Projeto.Data.Contexts;
using System.Linq;

namespace Projeto.Data.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        //atributo..
        private DataContext context;

        //construtor para receber o valor do atributo DataContext
        public ProdutoRepository(DataContext context)
        {
            this.context = context;
        }

        public void Inserir(Produto obj)
        {
            context.Entry(obj).State = EntityState.Added; //gravar
            context.SaveChanges(); //executando
        }

        public void Alterar(Produto obj)
        {
            context.Entry(obj).State = EntityState.Modified; //atualizar
            context.SaveChanges(); //executando
        }

        public void Excluir(Produto obj)
        {
            context.Entry(obj).State = EntityState.Deleted; //excluir
            context.SaveChanges();
        }

        public List<Produto> ConsultarTodos()
        {
            return context.Set<Produto>().ToList();
        }

        public Produto ConsultarPorId(int id)
        {
            return context.Set<Produto>().Find(id);
        }
    }
}
