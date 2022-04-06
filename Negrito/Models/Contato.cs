using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Negrito.Models
{
    [Table("Contato")]

    public class Contato
    {
        [Key]

        [Column("IDContato")]
        [Display(Name = "IDContato")]
        [Required]
        public int IDContato { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Nome { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Email { get; set; }

        [Column(TypeName = "nvarchar(15)")]
        [Display(Name = "Telefone")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Telefone { get; set; }

        [Column(TypeName = "nvarchar(500)")]
        [Display(Name = "Mensagem")]
        [Required(ErrorMessage = "Escreva o motivo do contato")]

        public string Mensagem { get; set; }


    }
}
