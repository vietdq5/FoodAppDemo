using AutoMapper;
using WavesOfFoodDemo.Server.Dtos;
using WavesOfFoodDemo.Server.Entities;

namespace WavesOfFoodDemo.Server
{
    public class UserInfoMapper : Profile
    {
        public UserInfoMapper()
        {
            CreateMap<UserInfoCreateDto, UserInfo>().ReverseMap()
                .ForAllMembers(opt => opt.Condition((src, dst, srcMember) => srcMember != null));
            CreateMap<UserInfo, UserInfoDto>().ReverseMap()
                .ForAllMembers(opt => opt.Condition((src, dst, srcMember) => srcMember != null));
            CreateMap<UserInfoDto, UserInfo>().ReverseMap()
                .ForAllMembers(opt => opt.Condition((src, dst, srcMember) => srcMember != null));
        }
    }
}
