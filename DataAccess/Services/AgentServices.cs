using DataAccess.DataAccess;
using DataAccess.Models;
using DataAccess.Models.Customer;
using DataAccess.Models.Employees;
using DataAccess.Repository;
using System;
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

        public List<Site> assignedClients(int id)
        {
            var clients = _context.Working
                     .Where(w => w.EmployeeId == id)
                     .Join(
                        _context.Sites,
                        w => w.SiteId,
                        c => c.SiteId,
                        (w, c) => c
                     );

            return clients.ToList();

        }

    }
}
