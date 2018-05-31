using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.ComponentModel.DataAnnotations;

namespace WebEmp.Models
{
    public class Pessoa
    {
        [BindNever]
        public int Id { get; set; }

        [Required(ErrorMessage = "O Nome deve ser informado!")]
        [StringLength(255, MinimumLength =2, ErrorMessage = "O Nome não é valido!")]
        [Display(Name = "Informe o Nome.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O Sexo deve ser informado!")]
        [Display(Name = "Informe o Sexo.")]
        public string Sexo { get; set; }

        [Required(ErrorMessage = "O E-mail deve ser informado!")]
        [EmailAddress(ErrorMessage = "E-mail inválido!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A data de nascimento deve ser informada!")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Nascimento { get; set; }
    }
}
