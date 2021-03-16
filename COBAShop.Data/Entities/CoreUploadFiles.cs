using System;
using System.Collections.Generic;
using System.Text;

namespace COBAShop.Data.Entities
{
    public class CoreUploadFiles
    {
        public Guid Id { get; set; }
        public DateTime Created { get; set; }

        public byte[] FileContent { get; set; }
        public string FileExtension { get; set; }
        public string MimeType { get; set; }
        public string Link { get; set; }
        public Guid RefId { get; set; }
    }
}