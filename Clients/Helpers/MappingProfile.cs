using AutoMapper;
using Clients.Core.Entities;
using Clients.Dtos.BillsDtos;

namespace Clients.Helpers
{
    public class MappingProfile : Profile
    {
        /// <summary>
        /// Mapping Profile for AutMapper
        /// </summary>
        public MappingProfile() {
            CreateMap<Bill, BillsDto>().ReverseMap();
        }
    }
}
