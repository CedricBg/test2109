﻿using AutoMapper;
using BUSI = BusinessAccessLayer.Models;
using API = test2109.Models;
using BusinessAccessLayer.Models.Employee;
using test2109.Models.Employee;

namespace test2109.Tools;

public class AutoMapperProfileApi : Profile
{
    public AutoMapperProfileApi()
    {
        CreateMap<BUSI.Employee.DetailedEmployee, DetailEmployed>().ReverseMap();
        CreateMap<BUSI.Employee.Email, API.Employee.Email>().ReverseMap();
        CreateMap<BUSI.Employee.Phone, API.Employee.Phone>().ReverseMap();
        CreateMap<BUSI.Employee.SendFoto, API.Employee.SendFoto>().ReverseMap();
        CreateMap<BUSI.Language, API.Employee.Language>().ReverseMap();
        CreateMap<BUSI.Role, API.Role>().ReverseMap();

        CreateMap<BUSI.Discussion.Messages, API.Discussion.Message>().ReverseMap();

        CreateMap<BUSI.Rondes.RfidPatrol, API.Ronde.RfidPatrol>().ReverseMap();
        CreateMap<BUSI.Rondes.RfidRound, API.Ronde.RfidRound>().ReverseMap();
        CreateMap<BUSI.Rondes.Rounds, API.Ronde.Rounds>().ReverseMap();
        CreateMap<BUSI.Rondes.PutRfidRounds, API.Ronde.PutRfidRounds>().ReverseMap();

        CreateMap<BUSI.Auth.AddRegisterForm, API.Auth.AddRegisterForm>().ReverseMap();

        CreateMap<API.Customer.Customers ,BUSI.Customers.Customers>()
            .ForMember(e => e.Site, x => x.MapFrom(y => y.Site))
            .ForMember(e => e.Role, x => x.MapFrom(y => y.Role))
            .ForMember(e => e.CustomerId, x => x.MapFrom(y => y.CustomerId))
            .ForMember(e => e.IsDeleted, x => x.MapFrom(y => y.IsDeleted))
            .ForMember(e => e.NameCustomer, x => x.MapFrom(y => y.NameCustomer))
            .ForMember(e => e.Contact, x => x.MapFrom(y => y.Contact))
            .ReverseMap();


        CreateMap<BUSI.Customers.ContactPerson, API.Customer.ContactPerson>().ReverseMap();
        CreateMap<BUSI.Customers.AllCustomers, API.Customer.AllCustomers>().ReverseMap();
        CreateMap<BUSI.Customers.AllSites, API.Customer.AllSites>().ReverseMap();
        CreateMap<BUSI.Customers.Site, API.Customer.Site>().ReverseMap();
        CreateMap<API.Address, BUSI.Employee.Address>() .ReverseMap();
        CreateMap<API.Pdf, BUSI.Pdf>().ReverseMap();
        CreateMap<API.Planning.StartEndTimeWork, BUSI.Planning.StartEndWorkTime>().ReverseMap();
        CreateMap<API.Planning.Working, BUSI.Planning.Working>().ReverseMap();
        CreateMap<API.Agents.AddSites, BUSI.Agents.AddSites>().ReverseMap();

    }
}
