using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.BL.Models
{
  public class City
  {
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int CityId { get; set; }
    public string CityName { get; set; } = "";
  }
}
