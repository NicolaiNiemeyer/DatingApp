using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.BL.Models
{
  public class Likes
  {
    public int LikesId { get; set; }
    public int? LikerId { get; set; } = 0;
    public int? LikeeId { get; set; } = 0;
    public int Status { get; set; } = 0;
    public Profile ProfileLiker { get; set; }
    public Profile ProfileLikee { get; set; }
    public bool? IsDeleted { get; set; }
  }
}
