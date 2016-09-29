namespace IQCWeb.DTO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public class DMR_Dispositions
    {
        
        public int DispID { get; set; }

        public int? InspID { get; set; }

        public byte? Disposition { get; set; }

        public DateTime? DispositionDate { get; set; }

        
        public string Comments { get; set; }
    }
}
