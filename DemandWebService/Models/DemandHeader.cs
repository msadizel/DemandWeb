using System;
using System.Collections.Generic;

namespace DemandWebService
{
    public partial class DemandHeader
    {
        public DemandHeader()
        {
            AttachmentHeader = new HashSet<AttachmentHeader>();
            DemandPurchase = new HashSet<DemandPurchase>();
        }

        public int DphId { get; set; }
        public string DphNum { get; set; }
        public DateTime DphDate { get; set; }
        public string DphCreator { get; set; }
        public string Department { get; set; }
        public int? Kod1C { get; set; }
        public int DphStatus { get; set; }
        public string Manager { get; set; }
        public string StatusComment { get; set; }
        public string DpJustification { get; set; }
        public int? ProjectId { get; set; }
        public string DepartmentExec { get; set; }
        public string Telephonenumber { get; set; }
        public string Email { get; set; }
        public string PhysicalDeliveryOfficeName { get; set; }
        public string WorkstationCorrector { get; set; }
        public string UserCorrector { get; set; }
        public int VersionEditing { get; set; }
        public string CustomerId { get; set; }
        public int? OtdelId { get; set; }
        public int? AppNum { get; set; }
        public DateTime? DateCorr { get; set; }
        public bool Favorites { get; set; }

        public virtual DpStatus DphStatusNavigation { get; set; }
        public virtual ProjectCost Project { get; set; }
        public virtual ICollection<AttachmentHeader> AttachmentHeader { get; set; }
        public virtual ICollection<DemandPurchase> DemandPurchase { get; set; }
    }
}
