using System;
using System.Collections.Generic;

#nullable disable

namespace Dal.Models
{
    public partial class Landing
    {
        public int Id { get; set; }
        public int PlaneId { get; set; }
        public DateTime Time { get; set; }
    }
}
