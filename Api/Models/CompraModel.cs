using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("tb_compra")]
    public class Compra
    {
        [Key]
        [Column("id_compra")]
        public Guid Id { get; set; }
        [ForeignKey("Produto")]
        [Column("id_produto")]
        public Guid IdProduto { get; set; }
        [ForeignKey("Usuario")]
        [Column("id_usuario")]
        public Guid IdUsuario { get; set; }
        [Required]
        [Column("quantidade")]
        public int Quantidade { get; set; }
        public Produto Produto { get; set; }
        public Usuario Usuario { get; set; }
    }
}