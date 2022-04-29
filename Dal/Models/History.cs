using System;
using System.Collections.Generic;

#nullable disable

namespace Dal.Models
{
    public partial class History
    {
        public int Id { get; set; }
        public string StationName { get; set; }
        public DateTime EnterTime { get; set; }
        public DateTime? LeavingTine { get; set; }
        public int PlaneId { get; set; }

        public virtual Plane IdNavigation { get; set; }
        public virtual Station StationNameNavigation { get; set; }
    }
}
