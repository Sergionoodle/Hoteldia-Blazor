using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hoteldia.Modelos
{
    public class Propiedad
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Descripcion{ get; set; }
        [Required]
        public int Area { get; set; }
        [Required]
        public int Habitaciones { get; set; }
        [Required]
        public int Banios { get; set; }
        [Required]
        public double Latitude { get; set; }
        [Required]
        public double Longitude { get; set; }
        [Required]
        public string Place { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public bool Activo { get; set; }

        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        public DateTime FechaActualizacion { get; set; }
        
        //Relación con el modelo categoria
        public int CategoriaId { get; set; }
        [ForeignKey("CategoriaId")]
        public virtual Categoria Categoria { get; set; }

        //Relacion imagen propiedad
        public virtual ICollection<ImagenPropiedad> ImagenPropiedad {  get; set; }
    }
}
