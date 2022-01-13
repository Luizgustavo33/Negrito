using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Negrito.Models
{
    [Table("Paciente")]
    public class Paciente
    {
        [Key]
        [Column("IDPaciente")]
        [Display(Name = "IDPaciente")]
        [Required]
        public int IDPaciente { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [Display(Name = "Nome")]
        [Required]
        public string Nome { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [Display(Name = "Email")]
        [Required]
        public string Email { get; set; }

        [Column(TypeName = "nvarchar(11)")]
        [Display(Name = "CPF")]


        [Required]
        public string CPF { get; set; }


        [Column(TypeName = "nvarchar(15)")]
        [Display(Name = "RG")]

        [Required]
        public string RG { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-mm-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data de nascimento")]

        [Required]
        public DateTime Data_Nascimento_Pac { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [Display(Name = "Endereço")]
        [Required]
        public string Endereço { get; set; }

        [Column(TypeName = "nvarchar(30)")]
        [Display(Name = "Bairro")]
        [Required]
        public string Bairro { get; set; }

        [Column(TypeName = "nvarchar(30)")]
        [Display(Name = "Cidade")]
        [Required]

        public string Cidade { get; set; }

        [Column(TypeName = "nvarchar(2)")]
        [Display(Name = "Estado")]
        [Required]
        public string Estado { get; set; }




        [Column(TypeName = "nvarchar(15)")]
        [Display(Name = "Telefone")]
        [Required]
        public string Telefone { get; set; }

        public ICollection<Agendamento> Agendamento { get; set; }

    }
}