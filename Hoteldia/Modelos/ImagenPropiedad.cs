using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hoteldia.Modelos
{
    public class ImagenPropiedad
    {
        [Key]
        public int Id { get; set; }

        public int PropiedadId { get; set; }

        public string UrlImagen { get; set; }

        [ForeignKey("PropiedadId")]
        public virtual Propiedad Propiedad { get; set; }
    }
}
