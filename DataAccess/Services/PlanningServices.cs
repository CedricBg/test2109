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
        public Working IsWorking(int id)
        {
            Working working = new Working();
            working.IsWorking = false;
            StartEndWorkTime workTime = _context.StartEndWorkTime.OrderByDescending(c => c.StartId).FirstOrDefault(c => c.EmployeeId == id);
            
            if(workTime != null)
            {
                working.CustomerId = workTime.CustomerId;
                working.EmployeeId = workTime.EmployeeId;
                working.IsWorking = false;
            }
            else
            {
                return working;
            }
            
            if (id < 1) 
                return working;
            else
            {   
                //n'a jamais travailler
                if (workTime == null)
                    return working;

                //déjà en service
                if (workTime.EndTime is null)
                {

                    working.IsWorking = true;
                    return working;
                }
                else 
                    return working;
            }
        }

        /// <summary>
        /// L'agent prend sont service
        /// </summary>
        /// <param name="form">IdCustomer, IdEmplyee, tout les autres paramètres ne servent pas</param>
        /// <returns>String line of answer</returns>
        public Working StartWork(StartEndWorkTime form)
        {
            Working working = new Working();
            working.IsWorking = false;
            if (form == null && form.EmployeeId == 0)
            {
                return working;
            }
            //déjà en service
            if(IsWorking(form.EmployeeId).IsWorking)
            {
                working.IsWorking = true;
                return working;
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
                working.EmployeeId = form.EmployeeId;
                working.CustomerId = form.CustomerId;
                working.IsWorking = true;
                return working;
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
            if (IsWorking(id).IsWorking)
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
        public List<Customers> Customers(int id)
        {
            var clients = _context.Working
                     .Where(w => w.EmployeeId == id)
                     .Join(
                        _context.Customers,
                        w => w.CustomerId,
                        c => c.CustomerId,
                        (w, c) => c
                     );

            return clients.ToList();
        }
    }
}
