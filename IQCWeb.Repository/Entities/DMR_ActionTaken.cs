namespace IQCWeb.Repository.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DMR_ActionTaken
    {
        [Key]
        public int ActID { get; set; }

        public int? InspID { get; set; }

        public byte? ActionTaken { get; set; }

        [StringLength(150)]
        public string OtherSpec { get; set; }

        [StringLength(255)]
        public string DescribeAction { get; set; }

        public bool? CA { get; set; }

        public bool? SCN { get; set; }

        public DateTime? CaClosed { get; set; }
    }
}
