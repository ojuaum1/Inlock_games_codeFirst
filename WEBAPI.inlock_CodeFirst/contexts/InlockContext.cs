using Microsoft.EntityFrameworkCore;
using webapi.inlock.codeFirst.manha.Domain;
using WEBAPI.inlock_CodeFirst.Domains;

namespace WEBAPI.inlock_CodeFirst.contexts
{
    public class InlockContext : DbContext
    {
        public DbSet<Estudio> Estudio { get; set; }
        public DbSet<Jogos> Jogos { get; set; }
        public DbSet<TiposUsuarios> TiposUsuario { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        //define as opções de construçao do banco (string conexão)

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=NOTE03-S15; Database=inlock_games_codeFirst_manha; User Id = sa; pwd = Senai@134; TrustServerCertificate=true;");
                base.OnConfiguring(optionsBuilder);
        }
    }
}
