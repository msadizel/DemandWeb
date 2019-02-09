using System;
using System.Collections.Generic;

namespace DemandWebService
{
    public partial class DpStatus
    {
        public DpStatus()
        {
            DemandArchive = new HashSet<DemandArchive>();
            DemandHeader = new HashSet<DemandHeader>();
            DemandHeaderArchive = new HashSet<DemandHeaderArchive>();
            DemandPurchase = new HashSet<DemandPurchase>();
        }

        public int DpStatusId { get; set; }
        public string DpStatus1 { get; set; }

        public virtual ICollection<DemandArchive> DemandArchive { get; set; }
        public virtual ICollection<DemandHeader> DemandHeader { get; set; }
        public virtual ICollection<DemandHeaderArchive> DemandHeaderArchive { get; set; }
        public virtual ICollection<DemandPurchase> DemandPurchase { get; set; }
    }
}
