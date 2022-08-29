using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.BL.Models
{
  public class Gender
  {
    public int GenderId { get; set; }
    public string SexName { get; set; } = "";
  }
}
