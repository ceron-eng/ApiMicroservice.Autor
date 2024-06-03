using ApiMicroservice.Autor.Models;
using AutoMapper;

namespace ApiMicroservice.Autor.Aplication
{
    public class MappingProfile : Profile
    {
        public MappingProfile() { 
            CreateMap<AutorLibro, AutorDto>();
        }
    }
}
