using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.BL.Models
{
  public class Chat
  { 
    public int ChatId { get; set; }
    public int? SenderId { get; set; } = 0;
    public int? ReceiverId { get; set; } = 0;
    public Profile ProfileSender { get; set; }
    public Profile ProfileReceiver { get; set; }
    public bool? ReadStatus { get; set; }
    public string Message { get; set; } = "";

  }
}
