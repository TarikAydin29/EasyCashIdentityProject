using AutoMapper;
using EasyCashIdentityProject.DtoLayer.Dtos.AppUserDtos;
using EasyCashIdentityProject.EntityLayer.Concrete;

namespace EasyCashIdentityProject.MVC.Mapping
{
    public class DtoMapping:Profile
    {
        public DtoMapping()
        {
            CreateMap<AppUser, AppUserRegisterDto>().ReverseMap();
        }
    }
}
