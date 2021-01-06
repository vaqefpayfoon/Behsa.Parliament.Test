using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Behsa.Parliament.Test.ViewModels
{
    public class ComplaintAccountVm : BaseComplaint
    {
        public string AccountName { get; set; }
        public string RegistrationNumber { get; set; }
        public string AccountActivityType { get; set; }
        public string AccountBusinessphone { get; set; }
        public string AccountNationalId { get; set; }
        public string AccountAddress { get; set; }
        public string CorporateBranding { get; set; }
    }
}