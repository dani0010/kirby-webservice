using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace kirby.models
{

    public class swatch
    {

        public int swatchId { get; set; }
        public string name { get; set; }
        public float width { get; set; }
        public float length { get; set; }
        public int stitches { get; set; }
        public int rows { get; set; }
        public yarn yarn { get; set; }
        public needle needle { get; set; }

    }
}