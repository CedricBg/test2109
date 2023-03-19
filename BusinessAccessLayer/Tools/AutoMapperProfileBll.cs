using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using BUSI = BusinessAccessLayer.Models;
using DATA = DataAccess.Models;

namespace BusinessAccessLayer.Tools
{
    public class AutoMapperProfileBll : Profile
    {
        public AutoMapperProfileBll()
        {
            CreateMap<DATA.Countrys, BUSI.Employee.Countrys>().ReverseMap();

            CreateMap<DATA.Employees.Employee, BUSI.Employee.Employee>().ReverseMap();
            
            CreateMap<BUSI.Employee.DetailedEmployee, DATA.Employees.DetailedEmployee>()
                .ForMember(e => e.Phone, x => x.MapFrom(y => y.Phone))
                .ForMember(e => e.Email, x => x.MapFrom(y => y.Email))
                .ForMember(e => e.Address, x => x.MapFrom(y => y.Address))
                .ForMember(e => e.Role, x => x.MapFrom(y => y.Role))
                .ForMember(e => e.Language,x => x.MapFrom(y => y.Language))
                .ReverseMap();

            CreateMap<BUSI.Customer.Customers, DATA.Customer.Customers>()
                .ForMember(e => e.GeneralEmail, x => x.MapFrom(y => y.GeneralEmail))
                .ForMember(e => e.EmergencyEmail, x => x.MapFrom(y => y.EmergencyEmail))
                .ForMember(e => e.GeneralPhone, x => x.MapFrom(y => y.GeneralPhone))
                .ForMember(e => e.EmergencyPhone, x => x.MapFrom(y => y.EmergencyPhone))
                .ForMember(e => e.Language, x => x.MapFrom(y => y.Language))
                .ForMember(e => e.Role, x => x.MapFrom(y => y.Role))
                .ForMember(e => e.Address, x => x.MapFrom(y => y.Address))
                .ReverseMap();


            CreateMap<DATA.Phone, BUSI.Employee.Phone>()
                .ReverseMap();
            CreateMap<DATA.Email, BUSI.Employee.Email>()
                .ReverseMap();
            CreateMap<DATA.Address, BUSI.Employee.Address>()
                .ReverseMap();
            CreateMap<DATA.Countrys, BUSI.Employee.Countrys>()
                .ReverseMap();
            CreateMap<DATA.Role, BUSI.Role>()
                .ReverseMap();
            CreateMap<DATA.Language, BUSI.Language>()
                .ReverseMap();
            CreateMap<DATA.Customer.ContactPerson, BUSI.Customer.ContactPerson>()
                .ReverseMap();
            CreateMap<DATA.Customer.CustomerAll, BUSI.Customer.CustomerAll>()
                .ReverseMap();
            CreateMap<DATA.Customer.Customers, BUSI.Customer.Customers>()
                .ReverseMap();
        }         
    }
}
