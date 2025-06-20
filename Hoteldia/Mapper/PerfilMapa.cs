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
            //Así podríamos hacer ambos mapeos y no tenemos que 
            //Duplicar como arriba
            CreateMap<Propiedad, PropiedadDTO>().ReverseMap();
            
            //Mapa para el dropdown de nuestra relacion
            CreateMap<Categoria, DropDownCategoriaDTO>().ReverseMap();

            //Agregamos el mapeo de imagenpropiedad
            CreateMap<ImagenPropiedad, ImagenPropiedadDTO>().ReverseMap();
        }
    }
}
