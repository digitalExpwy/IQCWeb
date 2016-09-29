namespace IQCWeb.Repository.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MainLocations
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LocationNum { get; set; }

        [StringLength(20)]
        public string LocationName { get; set; }
    }
}
