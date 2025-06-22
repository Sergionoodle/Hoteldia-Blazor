using AutoMapper;
using Hoteldia.Data;
using Hoteldia.Modelos;
using Hoteldia.Modelos.DTO;
using Hoteldia.Repositorio.IRespositorio;
using Microsoft.EntityFrameworkCore;

namespace Hoteldia.Repositorio
{
    public class ImagenPropiedadRepositorio : IImagenPropiedadRepositori
    {

        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public ImagenPropiedadRepositorio(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<int> BorrarImagenPorIdImagen(int imagenId)
        {
            var imagen = await _db.ImagenPropiedad.FindAsync(imagenId);
            _db.ImagenPropiedad.Remove(imagen);
            return await _db.SaveChangesAsync();
        }

        public async Task<int> BorrarImagenPorIdPropiedad(int propiedadId)
        {
            var imagenList = await _db.ImagenPropiedad.Where(x => x.Id == propiedadId).ToListAsync();
            _db.ImagenPropiedad.RemoveRange(imagenList);
            return await _db.SaveChangesAsync();
        }

        public async Task<int> BorrarImagenPorUrlImagen(string imagenUrl)
        {
            var allImgs = await _db.ImagenPropiedad.FirstOrDefaultAsync(
                x => x.UrlImagen.ToLower() == imagenUrl.ToLower());
            if(allImgs == null)
            {
                return 0;
            }
            _db.ImagenPropiedad.RemoveRange(allImgs);
            return await _db.SaveChangesAsync();
        }

        public async Task<int> CrearPropiedadImagen(ImagenPropiedadDTO imagenDTO)
        {
            var imagen = _mapper.Map<ImagenPropiedadDTO, ImagenPropiedad>(imagenDTO);
            await _db.ImagenPropiedad.AddAsync(imagen);
            return await _db.SaveChangesAsync();
        }


        public async Task<IEnumerable<ImagenPropiedadDTO>> GetImagenesPropiedad(int propiedadId)
        {
            return _mapper.Map<IEnumerable<ImagenPropiedad>, IEnumerable<ImagenPropiedadDTO>>(
                await _db.ImagenPropiedad.Where(x => x.Id == propiedadId).ToListAsync());
        }
    }
}
