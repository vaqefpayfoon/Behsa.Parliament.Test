using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Behsa.Parliament.Test.ViewModels
{
    public class ComplaintVm
    {
        public Guid Id { get; set; }
        public int AccuseType { get; set; }
        public ComplaintAccountVm ComplaintAccount { get; set; }
        public ComplaintContactVm ComplaintContact { get; set; }
        public ComplaintOrganizationVm ComplaintOrganization { get; set; }

    }
}