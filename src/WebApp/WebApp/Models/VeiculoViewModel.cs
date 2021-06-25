using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System;

namespace WebApp.Models
{
    public class VeiculoViewModel
    {
        [HiddenInput]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Marca é obrigatório")]
        [DisplayName("Marca:")]
        public string Marca { get; set; }

        [Required(ErrorMessage = "O campo Modelo é obrigatório")]
        [DisplayName("Modelo")]
        public string Modelo { get; set; }

        [Required(ErrorMessage = "O campo Quilometragem é obrigatório")]
        [DisplayName("Quilometragem")]
        public string Quilometragem { get; set; }

        [Required(ErrorMessage = "O campo Ano é obrigatório")]
        [DisplayName("Ano")]
        [DataType(DataType.Date)]
        public DateTime Ano { get; set; }
    }
}
