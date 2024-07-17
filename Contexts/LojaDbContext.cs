namespace Contexts
{

    public class LojaDbContext : DbContext
    {
        public LojaDbContext(DbContextOptions<LojaDbContext> configuracoes) : base (configuracoes)
        {}

        public DbSet<Usuario> usuario {get; set;}
        public DbSet<produto> produto {get; set;}
        public DbSet<Endereco> Endereco {get; set;}
        public DbSet<Credencial> Credencial {get; set;}
        public DbSet<Compra> Compra {get; set;}
        public DbSet<Categoria> Categoria {get; set;}

        protected override void OnModelCreating(ModelBuilder modelador)
        {
            //HasOne = 1
            //HasMany = N
            //WithOne = 1
            //WithMany = N

            //1:N
            modelador.Entity<Usuario>()
                .HasOne(usuario => usuario.Endereco)
                .WithMany()
                .HasForeignKey(usuario => usuario.EnderecoId);

            //1:1
            modelador.Entity<Usuario>()
                .HasOne(usuario => usuario.Credencial)
                .WithMany(credencial => credencial.Usuario)
                .HasForeignKey<Credencial>(credencial => credencial.UsuarioId);
        }
    }
}