using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;
using Historias.Veiculos;
using Infra.Contexto;
using Dominio.IRepositories;
using WebApp.Factories;

namespace AstroVeiculos.Controllers
{
    public class HomeController : Controller
    {
        private readonly CriarVeiculo _criarVeiculo;
        private readonly AlterarVeiculo _alterarVeiculo;
        private readonly ExcluirVeiculo _excluirVeiculo;
        private readonly ConsultasVeiculo _consultarVeiculo;

        private readonly DataContext _dataContext;
        public HomeController(IVeiculoRepository veiculoRepository, DataContext dataContext)
        {
            _criarVeiculo = new CriarVeiculo(veiculoRepository);
            _alterarVeiculo = new AlterarVeiculo(veiculoRepository);
            _excluirVeiculo = new ExcluirVeiculo(veiculoRepository);
            _consultarVeiculo = new ConsultasVeiculo(veiculoRepository);

            _dataContext = dataContext;
        }

        public async Task<IActionResult> PesquisaResult (string searchString)
        {
            var veiculos = from marca in _dataContext.Veiculos select marca;
            if (!string.IsNullOrEmpty(searchString))
            {
                veiculos = veiculos.Where(x => x.Marca.Contains(searchString));
            }
            var listaVeiculosViewModel = VeiculoFactory.MapearListaVeiculoViewModel(veiculos);
            return View(listaVeiculosViewModel);
        }


        public async Task<IActionResult> PesquisaModelo (string PesquisaModelo)
        {
            var veiculos = from modelo in _dataContext.Veiculos select modelo;
            if (!string.IsNullOrEmpty(PesquisaModelo))
            {
                veiculos = veiculos.Where(x => x.Modelo.Contains(PesquisaModelo));
            }
            var listaVeiculosViewModel = VeiculoFactory.MapearListaVeiculoViewModel(veiculos);
            return View(listaVeiculosViewModel);
        }



        public async Task<IActionResult> Index()
        {
            var listaVeiculos = await _consultarVeiculo.ListarTodosVeiculos();
            var listaVeiculoViewModel = VeiculoFactory.MapearListaVeiculoViewModel(listaVeiculos);
            return View(listaVeiculoViewModel);
        }
      
        public async Task<IActionResult> Alterar(int id)
        {
            var veiculo = await _consultarVeiculo.BuscarPeloId(id);
            if(veiculo == null)
            {
                return RedirectToAction("Index");
            }
            var veiculoViewModel = VeiculoFactory.MapearVeiculoViewModel(veiculo);
            return View(veiculoViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Alterar(int id, VeiculoViewModel veiculoViewModel)
        {
            if (ModelState.IsValid)
            {
                return View(veiculoViewModel);
            }
            var veiculo = VeiculoFactory.MapearVeiculo(veiculoViewModel);
            await _alterarVeiculo.Executar(id, veiculo);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Detalhar(int id)
        {
            var veiculo = await _consultarVeiculo.BuscarPeloId(id);
            if(veiculo == null)
            {
                return RedirectToAction("Index");
            }
            var veiculoViewModel = VeiculoFactory.MapearVeiculoViewModel(veiculo);
            return View(veiculoViewModel);
        }
        public async Task<IActionResult> Excluir(int id)
        {
            var veiculo = await _consultarVeiculo.BuscarPeloId(id);
            if(veiculo == null)
            {
                return RedirectToAction("Index");
            }
            await _excluirVeiculo.Executar(veiculo);
            return RedirectToAction("Index");
        }
    }
}

