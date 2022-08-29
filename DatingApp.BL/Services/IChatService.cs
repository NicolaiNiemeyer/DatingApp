using DatingApp.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.BL.Services
{
  public interface IChatService
  {
    List<Chat> GetChats();
    Chat GetChatDetails(int chatId);
    bool UpdateChat(Chat updatedetails);
    bool AddChat(Chat addChat);
    bool DeleteChat(Chat delChat);
  }
}
