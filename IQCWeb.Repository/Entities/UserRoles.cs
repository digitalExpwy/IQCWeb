namespace IQCWeb.Repository.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class UserRoles
    {
        [Key]
        [StringLength(10)]
        public string EID { get; set; }

        public bool Admin { get; set; }

        public bool FirstPceInspector { get; set; }

        public bool PartsMaint { get; set; }

        public bool EmployeeMaint { get; set; }

        public bool ReadOnly { get; set; }

        public bool Engineer { get; set; }
    }
}
