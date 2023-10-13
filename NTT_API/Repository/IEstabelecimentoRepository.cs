using NTT_API.Models;

namespace NTT_API.Repository
{
    public interface IEstabelecimentoRepository
    {
        Task<List<EstabelecimentoModel>> ListarEstab();

        Task<EstabelecimentoModel> AdicionarEstab(EstabelecimentoModel estabelecimento);

        Task<EstabelecimentoModel> ListarEstabid(int id);

        Task<EstabelecimentoModel> Atualizar(EstabelecimentoModel estabelecimento, int id);

    }
}
