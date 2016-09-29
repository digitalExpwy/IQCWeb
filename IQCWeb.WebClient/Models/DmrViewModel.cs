using IQCWeb.DTO;
using IQCWeb.WebClient.Helpers;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IQCWeb.WebClient.Models
{
    public class DmrViewModel
    {
        public IPagedList<IncomingDMR> PagedIncomingDMR { get; set; }
        public IncomingDMR DMR { get; set; }

        public IEnumerable<Employees> Employees { get; set; }
       
        public PagingInfo PagingInfo { get; set; }
    }

  

}