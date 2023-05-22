using DataAccess.Models.Discussion;

namespace DataAccess.Repository
{
    public interface IMessagesServices
    {
        List<string> GetMessages(int id);
        List<string> AddMessage(Message message);
    }
}