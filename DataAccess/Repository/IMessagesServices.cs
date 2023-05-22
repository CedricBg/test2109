namespace DataAccess.Repository
{
    public interface IMessagesServices
    {
        List<string> GetMessages(int id);
    }
}