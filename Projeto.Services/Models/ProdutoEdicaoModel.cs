using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Projeto.Services.Models
{
    public class ProdutoEdicaoModel
    {
        [Required(ErrorMessage = "Informe o nome do produto.")]
        public int IdProduto { get; set; }

        [Required(ErrorMessage = "Informe o nome do produto.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o preço do produto.")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "Informe a quantidade do produto.")]
        public int Quantidade { get; set; }
    }
}
