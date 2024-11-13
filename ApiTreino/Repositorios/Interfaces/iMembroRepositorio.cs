using ApiTreino.Models;

namespace ApiTreino.Repositorios.Interfaces
{
    public interface iMembroRepositorio
    {

        Task<List<MembroModel>> BuscarTodosMembros();
        Task<MembroModel> BuscarPorMembro(string nome);
        Task<MembroModel> Adicionar(MembroModel membro);
        Task<MembroModel> Atualizar(MembroModel membro, string nome);
        Task<bool> Apagar(string nome);

    }
}
