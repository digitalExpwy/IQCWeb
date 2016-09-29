namespace IQCWeb.Repository.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DesignSites
    {
        [Key]
        public byte DesignSiteID { get; set; }

        [StringLength(20)]
        public string DesignSite { get; set; }

        [StringLength(50)]
        public string Status { get; set; }

        public virtual ICollection<FirstPieceReports> FirstPieceReports { get; set; }
    }
}
