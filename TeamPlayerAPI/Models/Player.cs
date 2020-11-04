using System;
using System.Collections.Generic;

namespace TeamPlayerAPI.Models
{
    public class Player
    {
        public int PlayerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int TeamID { get; set; }

        //public virtual Team Team { get; set; }
    }
}
