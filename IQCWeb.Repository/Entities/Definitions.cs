namespace IQCWeb.Repository.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    
    public partial class Definitions
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DefinitionID { get; set; }

        [StringLength(100)]
        public string DefinitionName { get; set; }

        [StringLength(2000)]
        public string DefinitionText { get; set; }
    }
}
