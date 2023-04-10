﻿
using BusinessAccessLayer.Models.Customers;
using AllCustomers = BusinessAccessLayer.Models.Customers.AllCustomers;

namespace BusinessAccessLayer.IRepositories
{
    public interface ICustomerService
    {
        List<AllCustomers> All();
        Site GetCustomer(int id);
        Site UpdateSite(Site site);
        int AddCustomer(Customers customers);
        int? AddSite(Site site);
        int addContact(ContactPerson contact);
        string Delete(int id);
        List<Customers> UpdateCustomer(AllCustomers customer);
        Customers GetOne(int id);
    }
}