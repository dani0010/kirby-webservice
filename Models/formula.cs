using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace kirby.models
{

    public class formula
    {

        public int formulaId { get; set; }
        public string name { get; set; }
        public float neck { get; set; }
        public float arm { get; set; }
        public float cuff { get; set; }

    }
}