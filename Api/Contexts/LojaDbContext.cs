using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Models;

namespace Contexts
{
    public class LojaDbContext : DbContext
    {
        public LojaDbContext(DbContextOptions<LojaDbContext> configuracoes) : base (configuracoes)
        {
        }

        public DbSet<Usuario> Usuarios { get; set;}
        public DbSet<Produto> Produtos {get; set;}
        public DbSet<Endereco> Enderecos {get; set;}
        public DbSet<Credencial> Credenciais {get; set;}
        public DbSet<Compra> Compras {get; set;}

        protected override void OnModelCreating(ModelBuilder modelo)
        {

            //1:N
            modelo.Entity<Usuario>()
                .HasOne(usuario => usuario.Endereco)
                .WithOne(endereco => endereco.Usuario)    
                .HasForeignKey<Usuario>(usuario => usuario.EnderecoId);

            //1:1
            modelo.Entity<Usuario>()
                .HasOne(usuario => usuario.Credencial)
                .WithOne(credencial => credencial.Usuario)
                .HasForeignKey<Credencial>(credencial => credencial.UsuarioId);
            //1:N
            modelo.Entity<Produto>();
                
        }

        protected override void OnConfiguring(DbContextOptionsBuilder configuracoes)
        {
             configuracoes.ConfigureWarnings(mensagemAlerta => mensagemAlerta.Ignore(InMemoryEventId.TransactionIgnoredWarning));
        }
    }
}