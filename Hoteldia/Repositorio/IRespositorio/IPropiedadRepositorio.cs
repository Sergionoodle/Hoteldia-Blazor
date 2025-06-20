using Hoteldia.Modelos.DTO;

namespace Hoteldia.Repositorio.IRespositorio
{
    public interface IPropiedadRepositorio
    {
        //Indicamos todas las propiedades que vamos a obtener
        public Task<IEnumerable<PropiedadDTO>> GetAllPropiedads();

        //Devolvemos una unica propiedad donde le pasamos el ID
        public Task<PropiedadDTO> GetPropiedad(int propiedadId);

        //Creamos una propiedad
        public Task<PropiedadDTO> CrearPropiedad(PropiedadDTO propiedadDTO);

        public Task<PropiedadDTO> ActualizarPropiedad(int propiedadId, PropiedadDTO propiedadDTO);

        public Task<PropiedadDTO> PropiedadExists(string nombre);

        public Task<int> BorrarPropiedad(int propiedadId);
    }
}
