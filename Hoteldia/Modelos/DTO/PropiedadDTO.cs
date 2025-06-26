using System.ComponentModel.DataAnnotations;

namespace Hoteldia.Modelos.DTO
{
    public class PropiedadDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "El nombre debe tener entre 5 y 30 caracteres.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria.")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El área es obligatoria.")]
        [Range(1, 5000, ErrorMessage = "El área debe estar entre 1 y 5000 m².")]
        public int Area { get; set; }

        [Required(ErrorMessage = "El número de habitaciones es obligatorio.")]
        [Range(0, 10, ErrorMessage = "El número de habitaciones debe estar entre 0 y 10.")]
        public int Habitaciones { get; set; }

        [Required(ErrorMessage = "El número de baños es obligatorio.")]
        [Range(0, 10, ErrorMessage = "El número de baños debe estar entre 0 y 10.")]
        public int Banios { get; set; }

        [Required(ErrorMessage = "La latitud es obligatoria.")]
        public double Latitude { get; set; }

        [Required(ErrorMessage = "La longitud es obligatoria.")]
        public double Longitude { get; set; }

        [Required(ErrorMessage = "El lugar es obligatorio.")]
        public string Place { get; set; }

        [Required(ErrorMessage = "El precio es obligatorio.")]
        [Range(0, 999999, ErrorMessage = "El precio debe estar entre 0 y 999999.")]
        public double Price { get; set; }

        [Required(ErrorMessage = "El estado activo es obligatorio.")]
        public bool Activo { get; set; }

        //Relación con el modelo
        public int CategoriaId { get; set; }

        //Por aqui accederemos a la categoria
        public virtual Categoria Categoria { get; set; }

        public virtual ICollection<ImagenPropiedad> ImagenPropiedad { get; set; }

        public List<string> UrlImagenes { get; set; }
    }
}
