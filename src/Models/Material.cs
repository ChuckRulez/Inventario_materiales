using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventarioMateriales.Models
{
    /// <summary>
    /// Modelo que representa un material en el inventario
    /// </summary>
    [Table("Materiales")]
    public class Material
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required(ErrorMessage = "La categoría es requerida")]
        [StringLength(100, ErrorMessage = "La categoría no puede exceder 100 caracteres")]
        public string Categoria { get; set; } = string.Empty;

        [Required(ErrorMessage = "La descripción es requerida")]
        [StringLength(500, ErrorMessage = "La descripción no puede exceder 500 caracteres")]
        public string Descripcion { get; set; } = string.Empty;

        [StringLength(50)]
        public string? Numero_tipo { get; set; }

        [StringLength(50)]
        public string? Numero_pedido { get; set; }

        [Required(ErrorMessage = "El PVP es requerido")]
        [Range(0, 999999.99, ErrorMessage = "El PVP debe ser un valor válido")]
        public decimal PVP { get; set; }

        [Required(ErrorMessage = "El descuento es requerido")]
        [Range(0, 100, ErrorMessage = "El descuento debe estar entre 0 y 100")]
        public decimal Descuento { get; set; }

        [Required(ErrorMessage = "El neto es requerido")]
        [Range(0, 999999.99, ErrorMessage = "El neto debe ser un valor válido")]
        public decimal Neto { get; set; }

        [Required(ErrorMessage = "La unidad de empaque es requerida")]
        [Range(1, int.MaxValue, ErrorMessage = "La unidad de empaque debe ser mayor a 0")]
        public int UE { get; set; }

        [Required(ErrorMessage = "El neto por unidad de empaque es requerido")]
        [Range(0, 999999.99, ErrorMessage = "El neto por UE debe ser un valor válido")]
        public decimal Neto_UE { get; set; }

        [Required(ErrorMessage = "La fecha de precio es requerida")]
        public DateTime Fecha_precio { get; set; } = DateTime.Now;

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime Fecha_creacion { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime Fecha_actualizacion { get; set; }

        public override string ToString()
        {
            return $"{Categoria} - {Descripcion} ({Numero_pedido})";
        }
    }
}
