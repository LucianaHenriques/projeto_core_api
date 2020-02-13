using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations; //validações

namespace Projeto.Services.Models
{
    public class ProdutoCadastroModel
    {
        [Required(ErrorMessage = "Informe o nome do produto.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o preço do produto.")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "Informe a quantidade do produto.")]
        public int Quantidade { get; set; }
    }
}
