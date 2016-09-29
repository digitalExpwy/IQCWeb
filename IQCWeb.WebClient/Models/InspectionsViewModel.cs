using IQCWeb.DTO;
using IQCWeb.WebClient.Helpers;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IQCWeb.WebClient.Models
{
    public class InspectionsViewModel
    {
        public IPagedList<Inspections> Inspections { get; set; }

        public IEnumerable<Countries> Countries { get; set; }
        

        public PagingInfo PagingInfo { get; set; }
    }

}