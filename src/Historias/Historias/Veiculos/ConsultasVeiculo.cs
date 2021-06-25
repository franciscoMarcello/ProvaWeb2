using Dominio.Entidades;
using Dominio.IRepositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Historias.Veiculos
{
    public class ConsultasVeiculo
    {
        private readonly IVeiculoRepository _veiculoRepository;
        public ConsultasVeiculo(IVeiculoRepository veiculoRepository)
        {
            _veiculoRepository = veiculoRepository;
        }
        public async Task<Veiculo> BuscarPeloId(int id)
        {
            return await _veiculoRepository.BuscarPorId(id);
        }
        public async Task<IEnumerable<Veiculo>> ListarTodosVeiculos()
        {
            return await _veiculoRepository.ListarTodosVeiculos();
        }
    }
}
