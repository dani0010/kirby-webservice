using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace kirby.models

{
    public class sweater {
        public int sweaterId { get; set; }
        public string name { get; set; }
        public string recipient { get; set; }
        public size size { get; set; }
        public formula formula { get; set; }
        public swatch swatch { get; set; }
        public pattern pattern { get; set; }
    }

}