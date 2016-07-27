using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;


namespace kirby.models
{

    public class yarn
    {
        public int yarnId { get; set; }
        public string brand { get; set; }
        public string line { get; set; }
        public string product { get; set; }
        public string weight { get; set; }
        public string notes { get; set; }
    }
}