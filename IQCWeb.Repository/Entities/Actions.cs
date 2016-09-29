namespace IQCWeb.Repository.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Actions")]
    public partial class Actions
    {
        [Key]
        public byte ActionID { get; set; }

        [StringLength(30)]
        public string ActionTaken { get; set; }
    }
}
