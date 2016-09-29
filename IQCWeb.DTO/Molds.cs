namespace IQCWeb.DTO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public class Molds
    {
       
        public int MoldID { get; set; }

        public int InspID { get; set; }

        
        public string PartNum { get; set; }

        
        public string MoldNum { get; set; }

        public int? NumOfCavities { get; set; }

        
        public string ResinUsed { get; set; }

        
        public string MoldRev { get; set; }
    }
}
