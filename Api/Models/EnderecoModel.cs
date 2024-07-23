using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("tb_enderecos")]
    public class Endereco
    {
        [Key]

        [Column("id_endereco")]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(8)]
        [Column("cep")]
        public string cep { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("rua")]
        public string rua { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("bairro")]
        public string bairro { get; set; }

        [Required]
        [MaxLength(10)]
        [Column("numero")]
        public string numero { get; set; }

        [Required]
        [MaxLength(8)]
        [Column("complemento")]
        public string complemento { get; set; }

        [Required]
        [MaxLength(8)]
        [Column("estado")]
        public string estado { get; set; }

        [Required]
        [MaxLength(8)]
        [Column("cidade")]
        public string cidade { get; set; }

        public Usuario Usuario { get; set; }

       public List<Usuario>Usuarios;
    }
}