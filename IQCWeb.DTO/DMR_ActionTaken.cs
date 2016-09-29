namespace IQCWeb.DTO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public partial class DMR_ActionTaken
    {
        
        public int ActID { get; set; }

        public int? InspID { get; set; }

        public byte? ActionTaken { get; set; }
        
        public string OtherSpec { get; set; }
        
        public string DescribeAction { get; set; }

        public bool? CA { get; set; }

        public bool? SCN { get; set; }

        public DateTime? CaClosed { get; set; }
    }
}
