using System;
using System.Collections.Generic;

namespace DemandWebService
{
    public partial class Deputy
    {
        public int DeputyId { get; set; }
        public string ChiefName { get; set; }
        public string DeputyName { get; set; }
        public bool? FlagActing { get; set; }
        public bool FlagActingRequest { get; set; }
    }
}
