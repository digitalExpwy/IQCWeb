using IQCWeb.DTO;
using IQCWeb.WebClient.Helpers;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IQCWeb.WebClient.Models
{
    public class FprViewModel
    {
        public IPagedList<FirstPieceReports> PagedFirstPieceReports { get; set; }
        public FirstPieceReports FirstPieceReport { get; set; }

        public IEnumerable<Employees> Employees { get; set; }
       
        public PagingInfo PagingInfo { get; set; }
    }

  

}