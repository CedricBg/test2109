using AutoMapper;
using BusinessAccessLayer.Models.Employee;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using BUSI = BusinessAccessLayer.Models.Employee;
using DATA = DataAccess.Models;

namespace BusinessAccessLayer.Tools
{
    public class AutoMapperProfileBll : Profile
    {
        public AutoMapperProfileBll()
        {
            CreateMap<DATA.Countrys, BUSI.Countrys>().ReverseMap();
            CreateMap<DATA.Employees.Employee, BUSI.Employee>().ReverseMap();
            CreateMap<BUSI.DetailedEmployee, DATA.Employees.DetailedEmployee>()
                .ForMember(e => e.Phones, x => x.MapFrom(y => y.Phones))
                .ForMember(e => e.Emails, x => x.MapFrom(y => y.Emails))
                .ForMember(e => e.Address, x => x.MapFrom(y => y.Address))
                .ReverseMap();


            CreateMap<DATA.Phone, BUSI.Phone>()
                .ReverseMap();
            CreateMap<DATA.Email, BUSI.Email>()
                .ReverseMap();
            CreateMap<DATA.Address, BUSI.Address>()
                .ReverseMap();
            CreateMap<DATA.Countrys, BUSI.Countrys>()
                .ReverseMap();
        }         
    }
}
