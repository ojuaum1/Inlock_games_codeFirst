using WEBAPI.inlock_CodeFirst.Domains;

namespace WEBAPI.inlock_CodeFirst.Interfaces
{
    public interface IJogoRepository
    {
        List<Jogos> Listar();
        Jogos BuscarPorId(Guid id);

        void Cadastrar(Jogos jogos);

        void atualizar(Guid id, Jogos jogos);

        void Deletar(Guid id);
    }
}
