namespace IQCWeb.DTO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    
    public class Countries
    {
        
        public int CountryID { get; set; }

        
        public string Country { get; set; }

        public ICollection<Inspections> Inspections { get; set; }
    }
}
