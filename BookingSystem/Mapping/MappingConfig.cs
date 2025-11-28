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
            CreateMap<Packages, PackageDTO>().ReverseMap();
            CreateMap<UserPackage, UserPackageDTO>().ReverseMap();
            CreateMap<ClassSchedule, ClassDTO>().ReverseMap();
            CreateMap<booking, BookingDTO>().ReverseMap();

            //CreateMap<Purchase, PurchaseDTO>().ReverseMap();
            //CreateMap<Item, ItemDTO>().ReverseMap();
            //CreateMap<MemberDetail, MemberDetailDTO>().ReverseMap();

        }

    }
}
