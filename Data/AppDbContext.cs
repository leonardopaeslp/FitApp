using Microsoft.EntityFrameworkCore;
using WebApiExercisio.Models;

namespace WebApiExercisio.Data
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        public DbSet<PessoaModel> Pessoas { get; set; }
        public DbSet<AlteracaoDePesoModel> AlteracoesDePeso { get; set; }
        public DbSet<TipoExercicioModel> TiposDeExercicio { get; set; }
        public DbSet<ExercicioModel> Exercicios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Relação entre Pessoa e AlteracaoDePeso
            modelBuilder.Entity<PessoaModel>()
                .HasMany(ap => ap.AlteracoesDePeso)
                .WithOne(p => p.Pessoa)
                .HasForeignKey(ap => ap.PessoaId);

            //Relação entre Pessoa e Exercicio
            modelBuilder.Entity<PessoaModel>()
                .HasMany(e => e.Exercicios)
                .WithOne(p => p.Pessoa)
                .HasForeignKey(e => e.PessoaId);

            //Relação entre Exercicio e TipoExercicio
            modelBuilder.Entity<ExercicioModel>()
                .HasOne(te => te.TipoExercicio)
                .WithMany()
                .HasForeignKey(e => e.TipoExercicioId);
        }
    }
}
