using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mail;

namespace Models
{
[Table("tb_credenciais")]
public class Credencial    
    {
        [Key]

        [Column("id_credenciais")]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("email")]
        public string email { get; set; }

        [Required]
        [MaxLength(55)]
        [Column("senha")]
        public string senha { get; set; }

        // Acredito que este usuario ID não terá uso, mas vou deixar aqui para confirmar e por conta disso não coloquei a referencia de coluna na linha 23
        [ForeignKey("usuario")]
        public Guid UsuarioId { get; set; }
        
        public Usuario Usuario { get; set; }
    }
}