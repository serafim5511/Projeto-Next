using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNext.Models
{
    public class DadosPessoais
    {
        public DadosPessoais()
        {
            EnderecosResidencial = new EnderecoResidencial();
        }
        [Key()]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Nome { get; set; }
        public string CPF { get; set; }
        [DataType(DataType.Date)]
        public string DataNascimento { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
    
        [ForeignKey("EnderecosResidencial")]
        public int EnderecosResidencialId { get; set; }
        public virtual EnderecoResidencial EnderecosResidencial { get; set; }
        public string Senha { get; set; }

    }
}
