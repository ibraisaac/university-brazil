using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace university_brazil.Models
{
    public class UniversityModel
    {
        public string alpha_two_code { get; set; }

        public IEnumerable<string> web_pages { get; set; }

        public string name { get; set; }

        public string country { get; set; }

        public IEnumerable<string> domains { get; set; }

        public string state_province { get; set; }
    }
}
