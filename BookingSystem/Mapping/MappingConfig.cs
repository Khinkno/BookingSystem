using AutoMapper;
using BookingSystem.DTO;
using BookingSystem.Models;

namespace BookingSystem.Mapping
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<UserInfo, UserInfoDTO>().ReverseMap();
            CreateMap<Packages, packagesDTO>().ReverseMap();
            CreateMap<user_package, user_packageDTO>().ReverseMap();
            CreateMap<ClassSchedule, classDTO>().ReverseMap();
            CreateMap<booking, BookingDTO>().ReverseMap();

            //CreateMap<Purchase, PurchaseDTO>().ReverseMap();
            //CreateMap<Item, ItemDTO>().ReverseMap();
            //CreateMap<MemberDetail, MemberDetailDTO>().ReverseMap();

        }

    }
}
