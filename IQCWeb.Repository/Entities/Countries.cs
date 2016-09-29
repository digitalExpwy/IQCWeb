namespace IQCWeb.Repository.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Countries")]
    public partial class Countries
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CountryID { get; set; }

        [StringLength(50)]
        public string Country { get; set; }

        public virtual ICollection<Inspections> Inspections { get; set; }
    }
}
