
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("tb_usuarios")]
  public class Usuario{

        [Key]
        [Column("idUsuario")]
        public int IdUsuario { get; set; }
        [Required]
        [MaxLength(20)]
        [Column("nome")]
        public string Nome { get; set; }
        [Required]
        [MaxLength(20)]
        [Column("sobrenoe")]
        public string Sobrenome { get; set; }
        [Required]
        [MaxLength(15)]
        [Column("telefone")]
        public string telefone { get; set; }

        [ForeignKey("Endereco")]
        [Column("idEndereco")]
        public Guid EnderecoId { get; set; }

        [ForeignKey("Credencial")]
        [Column("idCredencial")]
        public Guid CredencialId { get; set; }
       
        public Endereco Endereco { get; set; }
        public Credencial Credencial { get; set; }
    }