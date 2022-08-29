using DatingApp.BL.Models;
using DatingApp.BL.Services;
using DatingApp.EntityFramework;
using DatingApp.UI.Services;

namespace DatingApp.UI.Data
{
  public class ChatRepository : IChatService
  {
    protected readonly ApplicationDbContext _dbcontext;
    protected readonly IChatService _IChatService;
    public ChatRepository(ApplicationDbContext _db, IChatService IChatService)
    {
      _dbcontext = _db;
      _IChatService = IChatService;
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

    public bool AddChat(Chat addChat)
    {
      _dbcontext.Chats.Add(addChat);
      _dbcontext.SaveChanges();
      return true;
    }

    public bool DeleteChat(Chat DelChat)
    {
      var getEmp = _dbcontext.Chats.FirstOrDefault(u => u.ChatId == DelChat.ChatId);
      if(getEmp != null)
      {
        _dbcontext.Remove(getEmp);
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
