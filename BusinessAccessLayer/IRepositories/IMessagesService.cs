namespace BusinessAccessLayer.IRepositories
{
    public interface IMessagesService
    {
        List<string> GetMessages(int id);
    }
}