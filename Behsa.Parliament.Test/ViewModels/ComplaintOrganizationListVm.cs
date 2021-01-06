using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Behsa.Parliament.Test.ViewModels
{
    public class ComplaintOrganizationListVm : Complaint
    {
        public ComplaintOrganizationListVm()
        {
            Complaints = new List<ComplaintOrganizationVm>();
        }
        public int AllComplaintsCount { get; set; }
        public int CurrentComplaintsCount { get; set; }
        public IList<ComplaintOrganizationVm> Complaints { get; set; }

        public class ComplaintOrganizationVm : BaseComplaint
        {
            public string OrganName { get; set; }
            public string OrganAddress { get; set; }
            public string OrganBusinessPhone { get; set; }
            public string OrganActivityType { get; set; }
        }
    }
}