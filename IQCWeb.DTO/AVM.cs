namespace IQCWeb.DTO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

  

    
    public class AVM
    {
       
        public int VendorID { get; set; }

        
        public string VendorName { get; set; }

        public ICollection<Inspections> Inspections { get; set; }
    }
}
