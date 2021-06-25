using Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace WebApp.Models
{
    public class HomeViewModel
    {
        public IList<Veiculo> ListVeiculo { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList Marcas { get; set; }

        [BindProperty(SupportsGet = true)]
        public string MarcaEscolhida { get; set; }
    }
}