using DataAccess.DataAccess;
using DataAccess.Models.Discussion;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Services
{
    public class MessagesServices : IMessagesServices
    {
        SecurityCompanyContext _securityCompanyContext;

        public MessagesServices(SecurityCompanyContext securityCompanyContext)
        {
            _securityCompanyContext = securityCompanyContext;
        }

        /// <summary>
        /// On récupère les messages par id de site
        /// </summary>
        /// <param name="id">id of site</param>
        /// <returns>List if string(messages)</returns>
        public List<string> GetMessages(int id)
        {
            if (id == 0)
                return new List<string>();
            List<string> messages = _securityCompanyContext.Message.Where(e => e.Site.SiteId == id).Select(e => e.Text).ToList();
            if (messages == null)
                return new List<string>();
            if (messages.Count == 0)
                return new List<string>();
            return messages;

        }
    }
}
