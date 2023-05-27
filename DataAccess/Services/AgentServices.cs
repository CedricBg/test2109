using DataAccess.DataAccess;
using DataAccess.Models;
using DataAccess.Models.Customer;
using DataAccess.Models.Employees;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Services
{
    public class AgentServices : IAgentServices
    {
        private readonly SecurityCompanyContext _context;

        public AgentServices(SecurityCompanyContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Sites assigné a un agent
        /// </summary>
        /// <param name="id">id of employee</param>
        /// <returns>List of Sites</returns>
        public List<Site> assignedClients(int id)
        {
            var clients = _context.Working
                     .Where(w => w.EmployeeId == id)
                     .Join(
                        _context.Sites.Include(x=>x.Customer),
                        w => w.SiteId,
                        c => c.SiteId,
                        (w, c) => c
                     );

            return clients.ToList();

        }

        /// <summary>
        /// Retourne tou les employee avec comme rolid de 1 a 15 (role des agents)
        /// </summary>
        /// <returns></returns>
        public List<Employee> assignedEmployees()
        {
            try
            {
                List<Employee> employees = _context.DetailedEmployees.Where(e => e.Role.Numero >= 1 && e.Role.Numero <= 15)
                    .Select(e => new Employee
                    {
                        firstName = e.firstName,
                        SurName = e.SurName,
                        Id = e.Id,
                        Role = e.Role,
                        Language = e.Language,
                    })
                    .ToList();
                return employees;
            } catch (Exception ex)
            {
                return new List<Employee>();
            }
        }

        /// <summary>
        /// Retourne un employee par rapport a l'id la on sait déjà que c'est un agent
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Employee</returns>
        public Employee GetAGuard(int id)
        {
            try
            {
                Employee employee = _context.DetailedEmployees.Where(e=>e.Id == id)
                    .Select(e=> new Employee
                    {
                        SurName= e.SurName,
                        firstName = e.firstName,
                        Id = e.Id,
                        Role = e.Role,
                        Language = e.Language

                    })
                    .FirstOrDefault();  
                return employee;
            }
            catch (Exception ex)
            {
                return new Employee();
            }
        }

        public List<Customers> assignedCustomers(int id)
        {
           List<Customers> listCustomer = new List<Customers>();
            var list = assignedClients(id);
            foreach (var customer in list)
            {
                if (!(listCustomer.Contains(customer.Customer))){
                    listCustomer.Add(customer.Customer);
                }
                
            }
            return listCustomer;
        }
    }
}
