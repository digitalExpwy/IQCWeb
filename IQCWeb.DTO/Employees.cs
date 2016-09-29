namespace IQCWeb.DTO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public class Employees
    {
       
        public int EmployeeCounter { get; set; }

        
        public string Name { get; set; }

        
        public string EmpFunction { get; set; }

        
        public string Status { get; set; }

        
        public string BuyerCode { get; set; }

        public bool? AlwaysOnEmail { get; set; }

        public bool? In_NY { get; set; }

        public bool? In_JZ { get; set; }

        public bool? In_EP { get; set; }

        public bool? In_SH { get; set; }

        
        public string EID { get; set; }
    }
}
