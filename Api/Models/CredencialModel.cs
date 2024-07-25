using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mail;

namespace Models
{
[Table("tb_credenciais")]
public class Credencial    
    {
        [Key]

        [Column("id_credencial")]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("email")]
        public string Email { get; set; }

        [Required]
        [MaxLength(55)]
        [Column("senha")]
        public string Senha { get; set; }

        [ForeignKey("usuario")]
        public Guid UsuarioId { get; set; }
    
        public Usuario Usuario { get; set; }
    }
}