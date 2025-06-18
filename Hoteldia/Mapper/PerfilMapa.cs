using AutoMapper;
using Hoteldia.Modelos;
using Hoteldia.Modelos.DTO;

namespace Hoteldia.Mapper
{
    public class PerfilMapa : Profile
    {
        public PerfilMapa() { 
            CreateMap<CategoriaDTO, Categoria>();
            CreateMap<Categoria, CategoriaDTO>();
        }
    }
}
