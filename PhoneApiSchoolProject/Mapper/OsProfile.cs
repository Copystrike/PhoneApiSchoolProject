using AutoMapper;
using PhoneApiSchoolProject.Models;
using PhoneApiSchoolProject.View;

namespace PhoneApiSchoolProject.Mapper;

public class OsProfile : Profile
{
    public OsProfile()
    {
        CreateMap<UpdateOsView, OsModel>()
            .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
        CreateMap<CreateOsView, OsModel>()
            .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
        CreateMap<OsModel, OsModel>()
            .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
        
    }
}