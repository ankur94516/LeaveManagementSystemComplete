namespace LeaveManagementSystem.Web.Mappings;

public class MappingProfile: Profile
{
    public MappingProfile()
    {
        // CreateMap<Source,Destination>();

        /*
        CreateMap<Iic, IicVM>()
            .ForMember(dest => dest.DepartmentName, o => o.MapFrom(src => src.Department.Name))
            .ForMember(dest => dest.PortfolioTypeName, o => o.MapFrom(src => src.PortfolioType.Name));
        */

        CreateMap<LeaveType, LeaveTypeReadOnlyVM>()
             // this comes at some performance cost
             .ForMember(dest => dest.Days, option => option.MapFrom(src => src.NumberOfDays));
        //.ReverseMap();

        CreateMap<LeaveTypeCreateVM, LeaveType>()
            .ForMember(dest => dest.NumberOfDays, option => option.MapFrom(src => src.Days));

        CreateMap<LeaveType, LeaveTypeEditVM>()
            .ForMember(dest => dest.Days, options => options.MapFrom(src => src.NumberOfDays))
            .ReverseMap();
    }
}
