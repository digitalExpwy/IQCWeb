namespace IQCWeb.Repository.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Molds
    {
        [Key]
        public int MoldID { get; set; }

        public int InspID { get; set; }

        [StringLength(30)]
        public string PartNum { get; set; }

        [StringLength(30)]
        public string MoldNum { get; set; }

        public int? NumOfCavities { get; set; }

        [StringLength(30)]
        public string ResinUsed { get; set; }

        [StringLength(5)]
        public string MoldRev { get; set; }

        public virtual Inspections Inspections { get; set; }
    }
}
