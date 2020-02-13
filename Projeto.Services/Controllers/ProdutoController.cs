using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto.Services.Models; //classes de modelo
using Projeto.Data.Entities;
using Projeto.Data.Contracts;

namespace Projeto.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        //método para realizar o cadastro do produto..
        [HttpPost]
        public IActionResult Post(ProdutoCadastroModel model, [FromServices] IProdutoRepository repository)
        {
            //se os dados da model passaram nas validações..
            if(ModelState.IsValid)
            {
                try
                {
                    var produto = new Produto();
                    produto.Nome = model.Nome;
                    produto.Preco = model.Preco;
                    produto.Quantidade = model.Quantidade;

                    repository.Inserir(produto);

                    return Ok("Produto cadastrado com sucesso!");
                }
                catch(Exception e)
                {
                    return StatusCode(500, e.Message);
                }                
            }
            else
            {
                return BadRequest("Erro de validação.");
            }            
        }

        //método para realizar a edição do produto..
        [HttpPut]
        public IActionResult Put(ProdutoEdicaoModel model, [FromServices] IProdutoRepository repository)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    var produto = new Produto();
                    produto.IdProduto = model.IdProduto;
                    produto.Nome = model.Nome;
                    produto.Preco = model.Preco;
                    produto.Quantidade = model.Quantidade;

                    repository.Alterar(produto);

                    return Ok("Produto atualizado com sucesso.");
                }
                catch(Exception e)
                {
                    return StatusCode(500, e.Message);
                }
            }
            else
            {
                return BadRequest("Erro de validação.");
            }            
        }

        //método para realizar a exclusão do produto..
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IProdutoRepository repository)
        {
            try
            {
                //buscar o produto pelo id..
                var produto = repository.ConsultarPorId(id);
                //excluindo o produto..
                repository.Excluir(produto);

                return Ok("Produto excluído com sucesso.");
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }            
        }

        //método para realizar a consulta de todos os produtos..
        [HttpGet]
        public IActionResult GetAll([FromServices] IProdutoRepository repository)
        {
            try
            {
                var lista = repository.ConsultarTodos();
                return Ok(lista);
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        //método para realizar a consulta de 1 produto pelo id..
        [HttpGet("{id}")]
        public IActionResult GetById(int id, [FromServices] IProdutoRepository repository)
        {
            try
            {
                var produto = repository.ConsultarPorId(id);
                return Ok(produto);
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}