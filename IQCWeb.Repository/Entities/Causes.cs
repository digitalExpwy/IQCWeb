namespace IQCWeb.Repository.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Causes")]
    public partial class Causes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CauseCode { get; set; }

        [StringLength(15)]
        public string AssignableCause { get; set; }

        [StringLength(2)]
        public string CauseLetter { get; set; }
    }
}
