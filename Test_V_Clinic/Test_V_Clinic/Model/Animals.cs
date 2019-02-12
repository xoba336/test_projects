using System;
using System.Collections.Generic;

namespace Test_V_Clinic.Model
{
    public partial class Animals
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? Height { get; set; }
        public decimal? Weight { get; set; }
        public bool? Indoor { get; set; }
        public string Nickname { get; set; }
    }
}