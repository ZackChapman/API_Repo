using System;
using System.Collections.Generic;

namespace TeamPlayerAPI.Models
{
    public class Team
    {
        //public Team()
        //{
        //    Player = new HashSet<Player>();
        //}

        public int TeamID { get; set; }
        public string TeamName { get; set; }
        public string Location { get; set; }

        //public virtual ICollection<Player> Player { get; set; }
    }
}
