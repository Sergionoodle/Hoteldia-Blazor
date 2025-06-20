using System.ComponentModel.DataAnnotations.Schema;

namespace Hoteldia.Modelos.DTO
{
    public class ImagenPropiedadDTO
    {
        public int Id { get; set; }

        public int PropiedadId { get; set; }

        public string UrlImagen { get; set; }

    }
}
