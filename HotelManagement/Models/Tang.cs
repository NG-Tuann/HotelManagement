using System;
using System.Collections.Generic;

#nullable disable

namespace HotelManagement.Models
{
    public partial class Tang
    {
        public Tang()
        {
            Phongs = new HashSet<Phong>();
        }

        public string Matang { get; set; }
        public int? Tang1 { get; set; }

        public virtual ICollection<Phong> Phongs { get; set; }
    }
}
