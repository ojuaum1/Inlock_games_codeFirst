namespace WEBAPI.inlock_CodeFirst.Utils
{
    public static class Criptografia
    {
        /// <summary>
        /// Gera uma Hash a partir de uma Senha
        /// </summary>
        /// <param name="senha">Senha que recebera a hash</param>
        /// <returns></returns>
        public static string GerarHash(string senha)
        { 
        return BCrypt.Net.BCrypt.HashPassword(senha);   
        }

        /// <summary>
        /// verifica se a Hash da senha informada 'e igual a hash salva no banco
        /// </summary>
        /// <param name="senhaForm">senha informada pelo usuario</param>
        /// <param name="senhaBanco">senha cadastrada pelo banco</param>
        /// <returns>senha e verdadeira</returns>
        public static bool CompararHash(string senhaForm, string senhaBanco)
        { 
        return BCrypt.Net.BCrypt.Verify(senhaForm,senhaBanco);
        }
    }
}
