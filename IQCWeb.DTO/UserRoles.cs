namespace IQCWeb.DTO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public class UserRoles
    {
        
        public string EID { get; set; }

        public bool Admin { get; set; }

        public bool FirstPceInspector { get; set; }

        public bool PartsMaint { get; set; }

        public bool EmployeeMaint { get; set; }

        public bool ReadOnly { get; set; }

        public bool Engineer { get; set; }
    }
}
