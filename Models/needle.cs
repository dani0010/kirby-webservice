using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace kirby.models
{

    public class needle
    {
        public int needleId { get; set; }
        public string brand { get; set; }
        public string line { get; set; }
        public string product { get; set; }
        public string material { get; set; }
        public string style { get; set; }
        public float mmSize { get; set; }
        
    }
}