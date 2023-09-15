using Microsoft.Data.SqlClient;
using webapi.inlock.codeFirst.manha.Domain;
using WEBAPI.inlock_CodeFirst.contexts;
using WEBAPI.inlock_CodeFirst.Interfaces;
using WEBAPI.inlock_CodeFirst.Utils;

namespace WEBAPI.inlock_CodeFirst.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        /// <summary>
        /// variavel privada e somente leitura para armazenar os dados do contexto
        /// </summary>
        private readonly InlockContext ctx;

        /// <summary>
        /// construtor do repositorio
        /// toda vez que o repositorio 
        /// ele tra acesso aos dados fornecidos pelo contexto
        /// </summary>
        public UsuarioRepository()
        {
            ctx = new InlockContext();
        }

        public Usuario BuscarUsuario(string email, string senha)
        {
            try
            {
              Usuario usuarioBuscado = ctx.Usuario.FirstOrDefault(u => u.Email == email)!;
                if (usuarioBuscado !=null)
                {
                   bool confere = Criptografia.CompararHash(senha, usuarioBuscado.Senha!);
                    if (confere) 
                    {
                    return usuarioBuscado;
                    }
                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public void cadastrar(Usuario usuario)
        {
            try
            {
                usuario.Senha = Criptografia.GerarHash(usuario.Senha!);
                ctx.Add(usuario);
                ctx.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }

        }

        public void Deletar(Guid id)
        {
            throw new NotImplementedException();
        }


        public UsuarioDomain Login(string email, string senha)
        {


            using (SqlConnection con = new SqlConnection(stringconexao))
            {
                string emailzinho = "SELECT IdUsuario, Email,Permissao from Usuario Where Email = @Email and Senha = @Senha";

                con.Open();

                SqlDataReader rdr;
                using (SqlCommand cmd = new SqlCommand(emailzinho, con))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Senha", senha);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        UsuarioDomain Usuario = new UsuarioDomain
                        {
                            IdUsuario = Convert.ToInt32(rdr["IdUsuario"]),

                            Email = rdr["Email"].ToString(),

                            Permissao = rdr["Permissao"].ToString()
                        };
                        return Usuario;
                    }
                    return null;
                }
            }

        }
    }


}

