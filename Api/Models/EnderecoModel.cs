using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("tb_enderecos")]
public class Endereco{
    [Key]
    [Column("idEndereco")]
    public Guid IdEndereco { get; set; }

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
    [Column("cep")]
    public string cep { get; set; }

    public Usuario Usuario { get; set; }
}