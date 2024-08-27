using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LINQComEFCore.Models
{
    class Produto
    {
        [Key]
        public int IdProduto { get; set; }

        [Required, MaxLength(100)]
        public string Nome { get; set; }

        public double Preco { get; set; }

        public int EstoqueAtual { get; set; }

        public int EstoqueMinimo { get; set; }

        public int IdCategoria { get; set; }

        [ForeignKey("IdCategoria")]
        public Categoria Categoria { get; set; }
    }
}
