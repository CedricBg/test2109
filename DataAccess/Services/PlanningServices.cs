using DataAccess.DataAccess;
using DataAccess.Models.Customer;
using DataAccess.Models.Employees;
using DataAccess.Models.Planning;
using DataAccess.Repository;
using DataAccess.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Services
{
    public class PlanningServices : IPlanningServices
    {
        private readonly SecurityCompanyContext _context;

        public PlanningServices(SecurityCompanyContext context)
        {
            _context = context;
        }
        /// <summary>
        /// On controle si il l'agent est en service pour la mise à jour de la vue la fonction StartWork
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Boolean IsWorking(int id)
        {
            if (id < 1)
                return false;
            else
            {
                StartEndWorkTime workTime = _context.StartEndWorkTime.OrderByDescending(c=>c.StartId).FirstOrDefault(c=>c.EmployeeId == id);
                //n'a jamais travailler
                if (workTime == null)
                    return false;

                //déjà en service
                if (workTime.EndTime is null)
                    return true;
                else 
                    return false;
            }
        }

        /// <summary>
        /// L'agent prend sont service
        /// </summary>
        /// <param name="form">IdCustomer, IdEmplyee, tout les autres paramètres ne servent pas</param>
        /// <returns>String line of answer</returns>
        public Boolean StartWork(StartEndWorkTime form)
        {

            if (form == null && form.EmployeeId == 0)
            {
                return false;
            }
            //déjà en service
            if(IsWorking(form.EmployeeId))
            {
                return true;
            }
            else
            {
                //On s'assure qu'aucune date de fin ne soit fournie
                StartEndWorkTime forms = new StartEndWorkTime
                {
                    ArrivingTime = DateTime.UtcNow.ToLocalTime(),
                    EndTime = null,
                    EmployeeId = form.EmployeeId,
                    CustomerId = form.CustomerId
                };

                _context.StartEndWorkTime.Add(forms);
                _context.SaveChanges();
                return true;
            }
        }

        /// <summary>
        /// L'agent fini sont service
        /// </summary>
        /// <param name="form">IdCustomer, IdEmplyee, tout les autres paramètres ne servent pas</param>
        /// <returns>String line of answer</returns>
        public Boolean EndWork(int id)
        {
            if(id == 0)
            {
                return false;
            }
            if (IsWorking(id))
            {
                StartEndWorkTime end = _context.StartEndWorkTime.OrderByDescending(c => c.StartId).FirstOrDefault(c => c.EmployeeId == id);
                end.EndTime = DateTime.UtcNow.ToLocalTime();
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        
        /// <summary>
        /// Renvoi la liste de tout les clients auquel l'agent est affecté pour qu'il puissent choissier sur quel site prendre son service
        /// </summary>
        /// <param name="id">Id de l'employée</param>
        /// <returns>list de clients</returns>
        public List<AllCustomers> Customers(int id)
        {
            List<AllCustomers> customers = All().ToList();
            List<Working> working = _context.Working.Where(c=>c.EmployeeId == id).ToList();
            List<AllCustomers> allCustomers  = new List<AllCustomers>();
            foreach (Working workingItem in working)
            {
                foreach(AllCustomers customersItem in customers)
                {
                    if(workingItem.CustomerId == customersItem.CustomerId)
                    {
                        allCustomers.Add(customersItem);
                    }
                }
            }
            return allCustomers;
        }

        /// <summary>
        /// Retorune tout les clients mour la fonction Customers
        /// </summary>
        /// <returns></returns>
        private List<AllCustomers> All()
        {
            List<AllCustomers> customers = new List<AllCustomers>();
            if (_context.Customers != null)
            {
                customers = _context.Customers
                    .Where(e => e.IsDeleted == false && e.Role.Name == "Client")
                    .Select((Client) => new AllCustomers
                    {
                        NameCustomer = Client.NameCustomer,
                        CustomerId = Client.CustomerId,
                    }
                    ).ToList();
            }
            return customers;
        }

    }
}
