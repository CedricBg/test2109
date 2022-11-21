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

            CreateMap<DATA.Employees.Employee, BUSI.Employee>().ReverseMap();
            CreateMap<BUSI.DetailedEmployee, DATA.Employees.DetailedEmployee>()
                .ForMember(e => e.Phones, x => x.MapFrom(y => y.Phones))
                .ReverseMap();


            CreateMap<DATA.Phone, BUSI.Phone>()
                .ReverseMap();


        }         
    }
}
