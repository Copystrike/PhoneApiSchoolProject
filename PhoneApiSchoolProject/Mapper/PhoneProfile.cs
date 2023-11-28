using AutoMapper;
using PhoneApiSchoolProject.Models;
using PhoneApiSchoolProject.View;

namespace PhoneApiSchoolProject.Mapper;

public class PhoneProfile : Profile
{
    public PhoneProfile()
    {
        CreateMap<UpdatePhoneView, PhoneModel>()
            .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
        CreateMap<CreatePhoneView, PhoneModel>()
            .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
        CreateMap<PhoneModel, PhoneModel>()
            .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
    }
}