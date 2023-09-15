using webapi.inlock.codeFirst.manha.Domain;
using WEBAPI.inlock_CodeFirst.Domains;

namespace WEBAPI.inlock_CodeFirst.Interfaces
{
    public interface IUsuarioRepository
    {
       Usuario BuscarUsuario(string email,string senha);

        void cadastrar(Usuario usuario);

        void Deletar(Guid id);
    }
}
