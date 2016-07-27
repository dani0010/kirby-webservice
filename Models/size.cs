using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace kirby.models
{

    public class size
    {

        public int sizeId { get; set; }
        public string name { get; set; }
        public float torso { get; set; }
        public float sleeveLen { get; set; }
        public float cuff { get; set; }
        public float bust { get; set; }
        public float hip { get; set; }
        public float neck { get; set; }

    }
}