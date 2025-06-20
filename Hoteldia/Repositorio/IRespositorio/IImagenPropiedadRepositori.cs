using Hoteldia.Modelos.DTO;

namespace Hoteldia.Repositorio.IRespositorio
{
    public interface IImagenPropiedadRepositori
    {

        public Task<int> CrearPropiedadImagen(ImagenPropiedadDTO imagenDTO);
        public Task<int> BorrarImagenPorIdImagen(int imagenId);
        public Task<int> BorrarImagenPorIdPropiedad(int propiedadId);
        public Task<int> BorrarImagenPorUrlImagen(string imagenUrl);
        public Task<IEnumerable<ImagenPropiedadDTO>> GetImagenesPropiedad(int propiedadId);


    }
}
