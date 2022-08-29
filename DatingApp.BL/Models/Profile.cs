using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.BL.Models
{
  public class Profile
  {
    public int ProfileId { get; set; }
    public DateTime BirthDate { get; set; }
    public int Height { get; set; }
    public int Weight { get; set; }
    public int CityId { get; set; }
    public City? City { get; set; }
    public int GenderId { get; set; }
    public Gender? Gender { get; set; }
    public DateTime? DeletedDate { get; set; }
    public DateTime CreatedDate { get; set; }
    public int AccountId { get; set; }
    public Account? Account { get; set; }
    public List<Chat> SendChats { get; set; }
    public List<Chat> ReceiveChats { get; set; }
    public List<Likes> SentLikes { get; set; }
    public List<Likes> ReceivedLikes { get; set; }
    public string PhotoPath { get; set; }
  }
}
