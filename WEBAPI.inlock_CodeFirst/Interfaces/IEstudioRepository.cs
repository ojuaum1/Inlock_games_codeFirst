
using WEBAPI.inlock_CodeFirst.Domains;

namespace webapi.inlock.dbFirst.Interfaces
{
    public interface IEstudioRepository
    {
        List<Estudio> Listar();

        Estudio BuscarporId(Guid id);

        void Cadastrar(Estudio estudio);

        void atualizar(Guid id, Estudio estudio);

        void Deletar(Guid id);

        List<Estudio> ListarComJogos();
    }

}
