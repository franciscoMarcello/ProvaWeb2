using Dominio.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dominio.IRepositories
{
    public interface IVeiculoRepository
    {
        Task Criar(Veiculo veiculo);
        Task Alterar(Veiculo veiculo);
        Task Excluir(Veiculo veiculo);
        Task<Veiculo> BuscarPorId(int id);
        Task<IEnumerable<Veiculo>> ListarTodosVeiculos();
    }
}
