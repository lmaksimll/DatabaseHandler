using System;
using System.Collections.Generic;
using System.Text;

namespace DateBase2
{
    public class residential_complex
    {
        public int id_residential_complex { get; set; }

        public string location { get; set; }

        public string developer { get; set; }

        public string title { get; set; }

        public residential_complex(int id_residential_complex, string location, string developer, string title)
        {
            this.id_residential_complex = id_residential_complex;
            this.location = location;
            this.developer = developer;
            this.title = title;
        }

        public override string ToString()
        {
            return $"{id_residential_complex}\t{location}\t{developer}\t{title}";
        }
    }
}
