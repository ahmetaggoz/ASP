using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;

namespace WebApi.Utilities.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ClothesDtoForUpdate, Clothes>().ReverseMap();
            CreateMap<Clothes, ClothesDto>();
            CreateMap<ClothesDtoForInsertion, Clothes>();
        }
    }
}
