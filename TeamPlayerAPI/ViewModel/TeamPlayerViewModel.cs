using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TeamPlayerAPI.ViewModel
{
    public class TeamPlayerViewModel
    {
        [Key]
        public int TeamID { get; set; }
        public string TeamName { get; set; }
        public string Location { get; set; }
        public int PlayerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
