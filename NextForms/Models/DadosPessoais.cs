using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextForms.Models
{
    class DadosPessoais
    {
        public DadosPessoais()
        {
            EnderecosResidencial = new EnderecoResidencial();
        }
        public int Id { get; set; }
        [Required(ErrorMessage = "Title is required")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Title is required")]
        public string CPF { get; set; }
        [Required(ErrorMessage = "Title is required")]
        public string DataNascimento { get; set; }
        [Required(ErrorMessage = "Title is required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Title is required")]
        public string Telefone { get; set; }
        [Required(ErrorMessage = "Title is required")]
        public int EnderecosResidencialId { get; set; }
        public virtual EnderecoResidencial EnderecosResidencial { get; set; }
        public string Senha { get; set; }
    }
}
