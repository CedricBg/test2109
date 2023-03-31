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

            CreateMap<BUSI.Language, API.Employee.Language>().ReverseMap();
            CreateMap<BUSI.Role, API.Role>().ReverseMap();

            
            CreateMap<BUSI.Customers.ContactPerson, API.Customer.ContactPerson>().ReverseMap();

            CreateMap<BUSI.Auth.ConnectedForm, API.Auth.ConnectedForm>().ReverseMap();
            CreateMap<BUSI.Auth.LoginForm, API.Auth.LoginForm>().ReverseMap();
            CreateMap<BUSI.Auth.AddRegisterForm, API.Auth.AddRegisterForm>().ReverseMap();

            CreateMap<API.Customer.Customers ,BUSI.Customers.Customers>()
                .ForMember(e => e.Site, x => x.MapFrom(y => y.Site))
                .ForMember(e => e.Role, x => x.MapFrom(y => y.Role))
                .ForMember(e => e.Id, x => x.MapFrom(y => y.Id))
                .ForMember(e => e.IsDeleted, x => x.MapFrom(y => y.IsDeleted))
                .ForMember(e => e.NameCustomer, x => x.MapFrom(y => y.NameCustomer))
                .ReverseMap();

            CreateMap<BUSI.Customers.AllCustomers, API.Customer.AllCustomers>()
               .ReverseMap();
            CreateMap<BUSI.Customers.AllSites, API.Customer.AllSites>()
               .ReverseMap();
            CreateMap<BUSI.Customers.Site, API.Customer.Site>()
                .ReverseMap();
            CreateMap<API.Address, BUSI.Employee.Address>()
                .ReverseMap();
        }
    }
}
