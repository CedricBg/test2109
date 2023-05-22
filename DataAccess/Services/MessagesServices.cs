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
            List<string> messages = _securityCompanyContext.Message.Where(e => e.SiteId == id).OrderByDescending(e=>e.MessageId).Take(5).Select(e => e.Text).ToList();
            if (messages == null)
                return new List<string>();
            if (messages.Count == 0)
                return new List<string>();
            return messages;

        }
        /// <summary>
        /// Post de un message
        /// </summary>
        /// <param name="message"></param>
        /// <returns>list of string</returns>
        public List<string> AddMessage(Message message)
        {
            if(message == null)
                return new List<string>();
            else
            {
                Message message1 = new Message{
                    Text = message.Text,
                    SiteId = message.SiteId,
                }
                ;
                _securityCompanyContext.Message.Add(message1);
                _securityCompanyContext.SaveChanges();
            }

            return GetMessages(message.SiteId);
        }
    }
}
