using AutoMapper;
using BUSI = BusinessAccessLayer.Models;
using API = test2109.Models;
using BusinessAccessLayer.Models.Employee;
using test2109.Models.Employee;

namespace test2109.Tools
{
    public class AutoMapperProfileApi : Profile
    {
        public AutoMapperProfileApi()
        {
            CreateMap<BUSI.Employee.DetailedEmployee, DetailEmployed>().ReverseMap();
            CreateMap<BUSI.Employee.Email, API.Employee.Email>().ReverseMap();
            CreateMap<BUSI.Employee.Phone, API.Employee.Phone>().ReverseMap();
            CreateMap<BUSI.Employee.Address, API.Address>().ReverseMap();
            CreateMap<BUSI.Role, API.Role>().ReverseMap();
            
        }
    }
}
