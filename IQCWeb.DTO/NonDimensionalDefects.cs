namespace IQCWeb.DTO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public class NonDimensionalDefects
    {
      
        public int NonDimDefect_ID { get; set; }

        public int FPR_ID { get; set; }

        public int? Item { get; set; }

        
        public string Defect { get; set; }

       
        public string SeeNote { get; set; }

        public byte? Allow { get; set; }

        public byte? PrevNotedOn { get; set; }
    }
}
