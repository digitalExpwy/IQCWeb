namespace IQCWeb.DTO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public class IIM
    {
        
        public string PartNum { get; set; }

        
        public string PartDesc { get; set; }

        public ICollection<Inspections> Inspections { get; set; }
    }
}
