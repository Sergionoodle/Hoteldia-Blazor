using AutoMapper;
using Hoteldia.Data;
using Hoteldia.Modelos;
using Hoteldia.Modelos.DTO;
using Hoteldia.Repositorio.IRespositorio;
using Microsoft.EntityFrameworkCore;

namespace Hoteldia.Repositorio
{
    //Extendemos de la interfaz de categoria repository
    public class CategoriaRepositorio : ICategoriaRepositorio
    {

        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public CategoriaRepositorio(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        //Implementamos los métodos de la interfaz
        public async Task<CategoriaDTO> ActualizarCategoria(int categoriaId, CategoriaDTO categoriaDTO)
        {
            try
            {
                if (categoriaId == categoriaDTO.Id)
                {
                    //Valido para actualizar y buscamos la categoria
                    Categoria categoria = await _db.Categorias.FindAsync(categoriaId);
                    //Mapeamos el dto con la categoria
                    Categoria cate = _mapper.Map<CategoriaDTO, Categoria>(categoriaDTO, categoria);

                    //La updateamos
                    var categoriaActualizada = _db.Categorias.Update(cate);
                    //Guardamos los datos de forma asincrona
                    await _db.SaveChangesAsync();

                    return _mapper.Map<Categoria, CategoriaDTO>(categoriaActualizada.Entity);
                } else
                {
                    //Invalido 
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        
        }

        public async Task<int> BorrarCategoria(int categoriaId)
        {
            var categoria = await _db.Categorias.FindAsync(categoriaId);
            if(categoria != null)
            {
                _db.Categorias.Remove(categoria);
                return await _db.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<CategoriaDTO> CategoriaExists(string nombre)
        {
            try
            {
                CategoriaDTO categoriaDTO =
                    _mapper.Map<Categoria, CategoriaDTO>(await _db.Categorias.FirstOrDefaultAsync(c => c.NombreCategoria.ToLower() == nombre.ToLower()));
                return categoriaDTO;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public async Task<CategoriaDTO> CrearCategoria(CategoriaDTO categoriaDTO)
        {
            Categoria categoria = _mapper.Map<CategoriaDTO, Categoria>(categoriaDTO);
            categoria.FechaCreacion = DateTime.Now;
            var categoriaAgregada = await _db.Categorias.AddAsync(categoria);
            await _db.SaveChangesAsync();
            return _mapper.Map<Categoria, CategoriaDTO>(categoriaAgregada.Entity);
        }

        public async Task<IEnumerable<CategoriaDTO>> GetAllCategorias()
        {
            try
            {
                IEnumerable<CategoriaDTO> categoriaDTO = _mapper.Map<IEnumerable<Categoria>, IEnumerable<CategoriaDTO>>(_db.Categorias);
                return (categoriaDTO);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<CategoriaDTO> GetCategoria(int categoriaId)
        {
            try
            {
                CategoriaDTO categoriaDTO =
                    _mapper.Map<Categoria, CategoriaDTO>(await _db.Categorias.FirstOrDefaultAsync(c => c.Id == categoriaId));
                return (categoriaDTO);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
