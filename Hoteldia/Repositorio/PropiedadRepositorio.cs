using AutoMapper;
using Hoteldia.Data;
using Hoteldia.Modelos;
using Hoteldia.Modelos.DTO;
using Hoteldia.Repositorio.IRespositorio;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Hoteldia.Repositorio
{
    public class PropiedadRepositorio : IPropiedadRepositorio
    {

        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public PropiedadRepositorio(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<PropiedadDTO> ActualizarPropiedad(int propiedadId, PropiedadDTO propiedadDTO)
        {
            try
            {
                if (propiedadId == propiedadDTO.Id)
                {
                    Propiedad propiedad = await _db.Propiedad.FindAsync(propiedadId);
                    Propiedad propiedadM = _mapper.Map<PropiedadDTO, Propiedad>(propiedadDTO, propiedad);
                    var propiedadUpdateada = _db.Propiedad.Update(propiedadM);
                    await _db.SaveChangesAsync();
                    return _mapper.Map<Propiedad, PropiedadDTO>(propiedadUpdateada.Entity);
                } else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<int> BorrarPropiedad(int propiedadId)
        {
            var propiedad = await _db.Propiedad.FindAsync(propiedadId);
            if (propiedad != null)
            {
                var imagenes = await _db.ImagenPropiedad.Where(img => img.Id == propiedadId).ToListAsync();
                _db.ImagenPropiedad.RemoveRange(imagenes);

                _db.Propiedad.Remove(propiedad);
                return await _db.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<PropiedadDTO> CrearPropiedad(PropiedadDTO propiedadDTO)
        {
            Propiedad propiedad = _mapper.Map<PropiedadDTO, Propiedad>(propiedadDTO);
            propiedad.FechaCreacion = DateTime.Now;
            var propiedadAgregada = await _db.Propiedad.AddAsync(propiedad);
            await _db.SaveChangesAsync();
            return _mapper.Map<Propiedad, PropiedadDTO>(propiedadAgregada.Entity);
        }

        public async Task<IEnumerable<PropiedadDTO>> GetAllPropiedads()
        {
            try 
            {
                IEnumerable<PropiedadDTO> propiedadDTO =
                    _mapper.Map<IEnumerable<Propiedad>, IEnumerable<PropiedadDTO>>
                    (_db.Propiedad.Include(x => x.ImagenPropiedad).Include(c => c.Categoria));
                return propiedadDTO;
            } 
            catch (Exception ex)
            {
                return null;
            }

            //Toca conseguir las imagenes, así que vamos a cambiar esto un poco 
            //try
            //{
            //    IEnumerable<PropiedadDTO> propiedadDTO = _mapper.Map<IEnumerable<Propiedad>, IEnumerable<PropiedadDTO>>(_db.Propiedad);
            //    return (propiedadDTO);
            //}
            //catch (Exception ex)
            //{
            //    return null;
            //}
        }

        public async Task<PropiedadDTO> GetPropiedad(int propiedadId)
        {
            try
            {
                PropiedadDTO propiedadDTO =
                    _mapper.Map<Propiedad, PropiedadDTO>(await _db.Propiedad.FirstOrDefaultAsync(p => p.Id == propiedadId));
                return (propiedadDTO);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<PropiedadDTO> PropiedadExists(string nombre)
        {
            try
            {
                PropiedadDTO propiedadDTO =
                    _mapper.Map<Propiedad, PropiedadDTO>(await _db.Propiedad.FirstOrDefaultAsync(p => p.Name.ToLower() == nombre.ToLower()));
                return propiedadDTO;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
