namespace IQCWeb.DTO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public class DMR_Attachments
    {
       
        public int Attachment_ID { get; set; }

        public int? DMR_ID { get; set; }

       
        public byte[] Attachment { get; set; }

        
        public string FileName { get; set; }
    }
}
