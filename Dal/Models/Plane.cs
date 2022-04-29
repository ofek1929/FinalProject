using System;
using System.Collections.Generic;

#nullable disable

namespace Dal.Models
{
    public partial class Plane
    {
        public int PlaneId { get; set; }
        public bool IsLanding { get; set; }

        public virtual History History { get; set; }
    }
}
