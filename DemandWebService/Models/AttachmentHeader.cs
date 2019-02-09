using System;
using System.Collections.Generic;

namespace DemandWebService
{
    public partial class AttachmentHeader
    {
        public int FileId { get; set; }
        public string FileName { get; set; }
        public byte[] FileAttach { get; set; }
        public int DphId { get; set; }

        public virtual DemandHeader Dph { get; set; }
    }
}
