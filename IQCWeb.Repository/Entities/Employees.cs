namespace IQCWeb.Repository.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Employees
    {
        [Key]
        public int EmployeeCounter { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string EmpFunction { get; set; }

        [StringLength(50)]
        public string Status { get; set; }

        [StringLength(50)]
        public string BuyerCode { get; set; }

        public bool? AlwaysOnEmail { get; set; }

        public bool? In_NY { get; set; }

        public bool? In_JZ { get; set; }

        public bool? In_EP { get; set; }

        public bool? In_SH { get; set; }

        [StringLength(10)]
        public string EID { get; set; }

        public virtual ICollection<Inspections> Inspections { get; set; }
              

    }
}
