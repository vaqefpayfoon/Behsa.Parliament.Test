using System;
using System.Collections.Generic;
using System.Text;

namespace Behsa.Parliament.Test.ViewModels
{
    public class IncidentVm
    {

        public Guid IncidentId { get; set; }
        public string IncidentTitle { set; get; }
        public Guid RequestGroupId { get; set; }
        public string RequestGroupName { get; set; }
        public Guid RequestSubGroupId { get; set; }
        public string RequestSubGroupName { get; set; }
        public string Description { set; get; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }


        public Guid? OwnerId { get; set; }//در صورتی که مالک کیس رئیس مجلس باشد بهتر است  مشخصات رئیس مجلس  لود نشود
        public string OwnerName { get; set; }
        public int RequestType { get; set; }/*1 means namayandeh , 2 means raees majles */

        public string Response { get; set; }
        public int StateCode { get; set; }
        public int StatusCode { get; set; }

        public string TicketNumber { get; set; }

        public Guid? CustomerId { get; set; }
        public string CustomerName { get; set; }

    }
}
