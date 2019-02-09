using System;
using System.Collections.Generic;

namespace DemandWebService
{
    public partial class ProjectCost
    {
        public ProjectCost()
        {
            DemandHeader = new HashSet<DemandHeader>();
            DemandHeaderArchive = new HashSet<DemandHeaderArchive>();
        }

        public int PId { get; set; }
        public string PDesignId { get; set; }
        public string PName { get; set; }

        public virtual ICollection<DemandHeader> DemandHeader { get; set; }
        public virtual ICollection<DemandHeaderArchive> DemandHeaderArchive { get; set; }
    }
}
