using System;
using System.Collections.Generic;

namespace DemandWebService
{
    public partial class DemandPurchase
    {
        public DemandPurchase()
        {
            AttachmentPurchase = new HashSet<AttachmentPurchase>();
        }

        public int DpId { get; set; }
        public int DphId { get; set; }
        public int? ItemCatNum { get; set; }
        public string DpSubject { get; set; }
        public string DpUnit { get; set; }
        public string DpComment { get; set; }
        public int DpNum { get; set; }
        public double DpAmount { get; set; }
        public int? FirmId { get; set; }
        public string FirmName { get; set; }
        public string ProdCatNum { get; set; }
        public string ProdCatNumExist { get; set; }
        public string QualificationId { get; set; }
        public int DpStatusId { get; set; }
        public DateTime? DateCorr { get; set; }
        public string WorkstationCorr { get; set; }
        public string UserCorr { get; set; }
        public string DepartmentExec { get; set; }
        public string DpExecutor { get; set; }
        public string ExecutorTelephone { get; set; }
        public string ExecutorMail { get; set; }
        public DateTime? DateWait { get; set; }
        public decimal? Price { get; set; }
        public bool? DpIsMobil { get; set; }
        public string Place { get; set; }
        public int? HousingId { get; set; }

        public virtual DpStatus DpStatus { get; set; }
        public virtual DemandHeader Dph { get; set; }
        public virtual ICollection<AttachmentPurchase> AttachmentPurchase { get; set; }
    }
}
