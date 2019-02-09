using System;
using System.Collections.Generic;

namespace DemandWebService
{
    public partial class DemandsInUse
    {
        public string Username { get; set; }
        public int DphId { get; set; }
        public DateTime StartTime { get; set; }
    }
}
