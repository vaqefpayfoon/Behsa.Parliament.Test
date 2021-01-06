using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Behsa.Parliament.Test.ViewModels
{
    public class ComplaintContactListVm : Complaint
    {
        public ComplaintContactListVm()
        {
            Complaints = new List<ComplaintContactVm>();
        }
        public int AllComplaintsCount { get; set; }
        public int CurrentComplaintsCount { get; set; }
        public IList<ComplaintContactVm> Complaints { get; set; }

        public class ComplaintContactVm : BaseComplaint
        {
            public string ContactName { get; set; }
            public string ContactLastName { get; set; }
            public string FathersName { get; set; }
            public string ContactNationalID { get; set; }
            public string ContactAddress { get; set; }
            public string ContactBusinessPhone { get; set; }
            public string Id { get; set; }//شماره شناسنامه
        }
    }
}