using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Negrito.Models
{
    [Table("Profissional")]
    public class Profissional
    {
        [Key]
        [Column("IDProfissional")]
        [Display(Name = "IDProfissional")]
        [Required (ErrorMessage = "Campo obrigatório")]
        public int IDProfissional { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Nome { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        [Display(Name = "Identidade de gênero")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string genero { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Email { get; set; }

        [Column(TypeName = "nvarchar(11)")]
        [Display(Name = "CPF")]
        [Required(ErrorMessage = "Campo obrigatório"), MaxLength(11), MinLength(11, ErrorMessage = "CPF deve ser formado por 11 dígitos numéricos")]
        public string CPF { get; set; }

        [Column(TypeName = "nvarchar(15)")]
        [Display(Name = "RG")]
        [Required(ErrorMessage = "Campo obrigatório"), MaxLength(15)]
        public string RG { get; set; }


        [Column(TypeName = "nvarchar(50)")]
        [Display(Name = "Endereço")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Endereço { get; set; }

        [Column(TypeName = "nvarchar(30)")]
        [Display(Name = "Bairro")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Bairro { get; set; }

        [Column(TypeName = "nvarchar(30)")]
        [Display(Name = "Cidade")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Cidade { get; set; }

        [Column(TypeName = "nvarchar(2)")]
        [Display(Name = "Estado")]
        [Required(ErrorMessage = "Campo obrigatório"), MaxLength(2), RegularExpression("^[A-Za-z]{2}$", ErrorMessage = "Insira a sigla do estado")]
        public string Estado { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-mm-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data de nascimento")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public DateTime Data_Nascimento_Pro { get; set; }

        [Column(TypeName = "nvarchar(15)")]
        [Display(Name = "Telefone")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Telefone { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        [Display(Name = "Numero do registro")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Registro { get; set; }

        public int Especialidades { get; set; }

        [ForeignKey("Especialidades")]


        public virtual Especialidade Especialidade { get; set; }


        public ICollection<Agendamento> Agendamento { get; set; }



    }
}
    