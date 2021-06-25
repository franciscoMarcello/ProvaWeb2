using Dominio.IRepositories;
using Historias.Veiculos;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApp.Factories;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class VeiculoController : Controller
    {
        private readonly CriarVeiculo _criarVeiculo;
        private readonly AlterarVeiculo _alterarVeiculo;
        private readonly ExcluirVeiculo _excluirVeiculo;
        private readonly ConsultasVeiculo _consultasVeiculo;
        public VeiculoController(IVeiculoRepository veiculoRepository)
        {
            _criarVeiculo = new CriarVeiculo(veiculoRepository);
            _alterarVeiculo = new AlterarVeiculo(veiculoRepository);
            _excluirVeiculo = new ExcluirVeiculo(veiculoRepository);
            _consultasVeiculo = new ConsultasVeiculo(veiculoRepository);
        }
        public async Task<IActionResult> Index()
        {
            var listaVeiculos = await _consultasVeiculo.ListarTodosVeiculos();
            var listaVeiculosViewModel = VeiculoFactory.MapearListaVeiculoViewModel(listaVeiculos);
            return View(listaVeiculosViewModel);
        }
        public IActionResult Criar()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Criar(VeiculoViewModel veiculoViewModel)
        {
            if (ModelState.IsValid)
            {
                var veiculo = VeiculoFactory.MapearVeiculo(veiculoViewModel);
                await _criarVeiculo.Executar(veiculo);
                return RedirectToAction("Index");
            }
            return View(veiculoViewModel);
        }
        public async Task<IActionResult> Alterar(int id)
        {
            var veiculo = await _consultasVeiculo.BuscarPeloId(id);
            if (veiculo == null)
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
            if (!ModelState.IsValid)
            {
                return View(veiculoViewModel);
            }
            var veiculo = VeiculoFactory.MapearVeiculo(veiculoViewModel);
            await _alterarVeiculo.Executar(id, veiculo);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Detalhar(int id)
        {
            var veiculo = await _consultasVeiculo.BuscarPeloId(id);
            if (veiculo == null)
            {
                return RedirectToAction("Index");
            }
            var veiculoViewModel = VeiculoFactory.MapearVeiculoViewModel(veiculo);
            return View(veiculoViewModel);
        }
        public async Task<IActionResult> Excluir(int id)
        {
            var veiculo = await _consultasVeiculo.BuscarPeloId(id);
            if (veiculo == null)
            {
                return RedirectToAction("Index");
            }
            await _excluirVeiculo.Executar(veiculo);
            return RedirectToAction("Index");
        }
    }
}

