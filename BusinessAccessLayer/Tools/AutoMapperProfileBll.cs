﻿using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using BUSI = BusinessAccessLayer.Models;
using DATA = DataAccess.Models;

namespace BusinessAccessLayer.Tools
{
    public class AutoMapperProfileBll : Profile
    {
        public AutoMapperProfileBll()
        { 
            CreateMap<DATA.Employees.Employee, BUSI.Employee.Employee>().ReverseMap();
            CreateMap<DATA.Employees.SendFoto, BUSI.Employee.SendFoto>().ReverseMap();          
            CreateMap<BUSI.Employee.DetailedEmployee, DATA.Employees.DetailedEmployee>()
                .ForMember(e => e.Phone, x => x.MapFrom(y => y.Phone))
                .ForMember(e => e.Email, x => x.MapFrom(y => y.Email))
                .ForMember(e => e.Address, x => x.MapFrom(y => y.Address))
                .ForMember(e => e.Role, x => x.MapFrom(y => y.Role))
                .ForMember(e => e.Language,x => x.MapFrom(y => y.Language))
                .ReverseMap();

            CreateMap<BUSI.Customers.Customers, DATA.Customer.Customers>()
                .ForMember(e => e.Site, x => x.MapFrom(y => y.Site))
                .ForMember(e => e.Role, x => x.MapFrom(y => y.Role))
                .ForMember(e => e.CustomerId, x => x.MapFrom(y => y.CustomerId))
                .ForMember(e => e.IsDeleted, x => x.MapFrom(y => y.IsDeleted))
                .ForMember(e => e.NameCustomer, x => x.MapFrom(y => y.NameCustomer))
                .ForMember(e => e.Contact, x => x.MapFrom(y => y.Contact))
                .ReverseMap();
            CreateMap<DATA.Customer.Site, BUSI.Customers.Site>()
                .ForMember(e => e.ContactSite, x => x.MapFrom(y => y.ContactSite))
                .ReverseMap();
            CreateMap<DATA.Customer.ContactPerson, BUSI.Customers.ContactPerson>()
                .ForMember(e => e.Phone, x => x.MapFrom(y => y.Phone))
                .ForMember(e => e.Email, x => x.MapFrom(y => y.Email))
                .ReverseMap();
            CreateMap<DATA.Customer.AllSites, BUSI.Customers.AllSites>().ReverseMap();
            CreateMap<DATA.Customer.AllCustomers, BUSI.Customers.AllCustomers>().ReverseMap();

            CreateMap<DATA.Phone, BUSI.Employee.Phone>().ReverseMap();
            CreateMap<DATA.Email, BUSI.Employee.Email>().ReverseMap();
            CreateMap<DATA.Address, BUSI.Employee.Address>().ReverseMap();
            CreateMap<DATA.Countrys, BUSI.Employee.Countrys>().ReverseMap();
            CreateMap<DATA.Role, BUSI.Role>().ReverseMap();
            CreateMap<DATA.Language, BUSI.Language>().ReverseMap();
            CreateMap<DATA.Countrys, BUSI.Employee.Countrys>().ReverseMap();
            CreateMap<DATA.Auth.AddRegisterForm, BUSI.Auth.AddRegisterForm>().ReverseMap();
            CreateMap<DATA.Agents.AddSites, BUSI.Agents.AddSites>().ReverseMap();
            CreateMap<DATA.Pdf, BUSI.Pdf>().ReverseMap();
            CreateMap<DATA.Discussion.Message, BUSI.Discussion.Messages>().ReverseMap();

           
            CreateMap<DATA.Rondes.RfidPatrol, BUSI.Rondes.RfidPatrol>().ReverseMap();
            CreateMap<DATA.Rondes.RfidRound, BUSI.Rondes.RfidRound>().ReverseMap();
            CreateMap<DATA.Rondes.Rounds, BUSI.Rondes.Rounds>().ReverseMap();
            CreateMap<DATA.Rondes.PutRfidRounds, BUSI.Rondes.PutRfidRounds>().ReverseMap();

            CreateMap<DATA.Planning.StartEndWorkTime, BUSI.Planning.StartEndWorkTime>().ReverseMap();
            CreateMap<DATA.Planning.Working, BUSI.Planning.Working>().ReverseMap();
        }         
    }
}
