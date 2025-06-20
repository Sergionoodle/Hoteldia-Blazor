using Hoteldia.Modelos.DTO;

namespace Hoteldia.Repositorio.IRespositorio
{
    public interface ICategoriaRepositorio
    {
        //Indicamos todas las categorias que vamos a obtener
        public Task<IEnumerable<CategoriaDTO>> GetAllCategorias();

        //Devolvemos una unica categoria donde le pasamos el ID
        public Task<CategoriaDTO> GetCategoria(int categoriaId);

        //Creamos una categoria
        public Task<CategoriaDTO> CrearCategoria(CategoriaDTO categoriaDTO);

        public Task<CategoriaDTO> ActualizarCategoria(int categoriaId, CategoriaDTO categoriaDTO);

        public Task<CategoriaDTO> CategoriaExists(string nombre);

        public Task<int> BorrarCategoria(int categoriaId);
        
        //Vamos a sacar nuestro desplegable de categorias
        public Task<IEnumerable<DropDownCategoriaDTO>> GetDropDownCategorias();
    }
}
