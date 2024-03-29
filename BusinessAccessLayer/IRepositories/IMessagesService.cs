﻿using BusinessAccessLayer.Models.Discussion;

namespace BusinessAccessLayer.IRepositories
{
    public interface IMessagesService
    {
        List<string> GetMessages(int id);
        List<string> AddMessage(Messages message);
    }
}