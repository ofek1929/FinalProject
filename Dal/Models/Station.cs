using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Dal.Models
{
    public partial class Station
    {
        public Station()
        {
            Histories = new HashSet<History>();
        }

        public string StationName { get; set; }
        public int PlaneId { get; set; }

        public virtual ICollection<History> Histories { get; set; }
    }
}
