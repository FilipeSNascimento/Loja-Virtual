using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("tb_produtos")]
    public class Produto
    {
        [Key]

        [Column("id_produto")]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("nome")]
        public string Nome { get; set;}

        [Column("descricao")]
        public string Descricao { get; set;}
        
    }
}