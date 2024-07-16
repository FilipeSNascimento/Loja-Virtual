using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mail;

[Table("tb_credenciais")]
public class Credencial {

        [Key]
        [Column("idCredenciais")]
    public Guid IdCredenciais { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("email")]
    public string email { get; set; }

        [Required]
        [MaxLength(55)]
        [Column("senha")]
    public string senha { get; set; }

// Acredito que este usuario ID não terá uso, mas vou deixar aqui para confirmar e por conta disso não coloquei a referencia de coluna na linha 23
    public Guid UsuarioId { get; set; }
    public Usuario Usuario { get; set; }
}