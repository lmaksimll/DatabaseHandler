using System;
using System.Collections.Generic;
using System.Text;

namespace DateBase2
{
    class building
    {
        public int id_building { get; set; }

        public string address { get; set; }

        public residential_complex idresidential_complex { get; set; }

        public building(int id_building, string address, residential_complex idresidential_complex)
        {
            this.id_building=id_building;
            this.address=address;
            this.idresidential_complex=idresidential_complex;
        }

        public override string ToString()
        {
            return $"{id_building}\t{address}\t{idresidential_complex}";

        }
    }
}
