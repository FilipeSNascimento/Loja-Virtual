using System.Collections.Generic;
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
        public string Cep { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("rua")]
        public string Rua { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("bairro")]
        public string Bairro { get; set; }

        [Required]
        [MaxLength(10)]
        [Column("numero")]
        public string Numero { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("complemento")]
        public string Complemento { get; set; }

        [Required]
        [MaxLength(20)]
        [Column("estado")]
        public string Estado { get; set; }

        [Required]
        [MaxLength(30)]
        [Column("cidade")]
        public string Cidade { get; set; }
        public Usuario Usuario { get; set; }
    }
}