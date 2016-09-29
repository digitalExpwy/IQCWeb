namespace IQCWeb.Repository.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DMR_Attachments
    {
        [Key]
        public int Attachment_ID { get; set; }

        public int? DMR_ID { get; set; }

        [Column(TypeName = "image")]
        public byte[] Attachment { get; set; }

        [StringLength(250)]
        public string FileName { get; set; }
    }
}
