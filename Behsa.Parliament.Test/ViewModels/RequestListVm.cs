using System;
using System.Collections.Generic;
using System.Text;

namespace Behsa.Parliament.Test.ViewModels
{
    public class RequestListVm
    {
        public RequestListVm()
        {
            AllRequests = new List<AllRequestVm>();
        }
        public int AllRequestsCount { get; set; }
        public int CurrentAllRequestsCount { get; set; }
        public IList<AllRequestVm> AllRequests { get; set; }
    }
    public class AllRequestVm
    {
        public Guid CustomerId { get; set; }
        public Guid EntityId { get; set; }
        public string EntityTypeCode { get; set; }
        public string TicketNumber { get; set; }
        public string ApplicationType { get; set; }
        public string Topic { get; set; }
        public string StateCode { get; set; }
        public string Createdon { get; set; }

    }
}
