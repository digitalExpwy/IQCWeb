namespace IQCWeb.DTO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public class DimensionalDefects
    {
       
        public int Defect_ID { get; set; }

        public int FPR_ID { get; set; }

        public int? Item { get; set; }

        
        public string Dimension { get; set; }

        
        public string Measured { get; set; }

        
        public string ViewGridLocation { get; set; }

        public byte? Allow { get; set; }

        public byte? PrevNotedOn { get; set; }
    }
}
