using System;
using System.Collections.Generic;

namespace DemandWebService
{
    public partial class AttachmentPurchase
    {
        public int FileId { get; set; }
        public string FileName { get; set; }
        public byte[] FileAttach { get; set; }
        public int DpId { get; set; }

        public virtual DemandPurchase Dp { get; set; }
    }
}
