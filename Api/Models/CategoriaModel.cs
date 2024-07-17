using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("tb_categorias")]
    public class Categoria
    {
        [Key]

        [Column("id_categoria")]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(30)]
        [Column("nome")]
        public string Nome { get; set; }
        
        public Produto Produto{ get; set; }
    }
}