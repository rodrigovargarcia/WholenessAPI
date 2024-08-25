using AutoMapper;
using WholenessAPI.DTOs;
using WholenessAPI.Entities;

namespace WholenessAPI.Helpers
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Sucursal, SucursalDTO>().ReverseMap();
        }
    }
}
