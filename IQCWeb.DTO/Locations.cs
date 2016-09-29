namespace IQCWeb.DTO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public class Locations
    {
       
        public byte LocationID { get; set; }

       
        public string Location { get; set; }

        public int? Fac { get; set; }

       
        public string Status { get; set; }
    }
}
