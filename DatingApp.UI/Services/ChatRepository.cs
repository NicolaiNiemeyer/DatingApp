using DatingApp.BL.Models;
using DatingApp.EntityFramework;

namespace DatingApp.UI.Services
{
    public class ChatRepository
    {
    public class ChatServices
    {

      protected readonly ApplicationDbContext _dbcontext;
      public ChatServices(ApplicationDbContext _db)
      {
        _dbcontext = _db;
      }

      public List<Chat> GetChats()
      {
        return _dbcontext.Chats.ToList();
      }

      public Chat GetChatDetails(int chatId)
      {
        Chat editobj = new Chat();
        return _dbcontext.Chats.FirstOrDefault(u => u.ChatId == chatId);
      }

      public bool UpdateChat(Chat updatedetails)
      {
        var GetChats = _dbcontext.Chats.FirstOrDefault(u => u.ChatId == updatedetails.ChatId);
        if (GetChats != null)
        {
          GetChats.SenderId = updatedetails.SenderId;
          GetChats.ReceiverId = updatedetails.ReceiverId;
          GetChats.ReadStatus = updatedetails.ReadStatus;
          GetChats.Message = updatedetails.Message;
          _dbcontext.SaveChanges();
        }
        else
        {
          return false;
        }
        return true;
      }

      public bool AddChat(Chat ecadd)
      {
        _dbcontext.Chats.Add(ecadd);
        _dbcontext.SaveChanges();
        return true;
      }

      public bool DeleteChat(Chat DelChat)
      {
        var Getemp = _dbcontext.Chats.FirstOrDefault(u => u.ChatId == DelChat.ChatId);
        if (Getemp != null)
        {
          _dbcontext.Remove(Getemp);
          _dbcontext.SaveChanges();
        }
        else
        {
          return false;
        }
        return true;
      }
    }
  }
}
