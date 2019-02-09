using System;
using System.Collections.Generic;

namespace DemandWebService
{
    public partial class DemandHeaderArchive
    {
        public DemandHeaderArchive()
        {
            DemandArchive = new HashSet<DemandArchive>();
        }

        public int DahId { get; set; }
        public int DphId { get; set; }
        public string DphNum { get; set; }
        public DateTime DphDate { get; set; }
        public string DphCreator { get; set; }
        public string Department { get; set; }
        public int DphStatus { get; set; }
        public string Manager { get; set; }
        public string StatusComment { get; set; }
        public string DpJustification { get; set; }
        public int? ProjectId { get; set; }
        public string DepartmentExec { get; set; }
        public string Telephonenumber { get; set; }
        public string Email { get; set; }
        public string PhysicalDeliveryOfficeName { get; set; }
        public string UserCorrector { get; set; }
        public string WorkstationCorrector { get; set; }
        public DateTime DateCorrection { get; set; }
        public string DahAction { get; set; }
        public string DahFieldsChanged { get; set; }
        public int VersionEditing { get; set; }
        public string TokenTrans { get; set; }

        public virtual DpStatus DphStatusNavigation { get; set; }
        public virtual ProjectCost Project { get; set; }
        public virtual ICollection<DemandArchive> DemandArchive { get; set; }
    }
}
