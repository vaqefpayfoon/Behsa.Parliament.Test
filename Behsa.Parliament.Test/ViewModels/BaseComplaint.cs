using System;
using System.Collections.Generic;
using System.Text;

namespace Behsa.Parliament.Test.ViewModels
{
    public interface Complaint { }
    public class BaseComplaint : Complaint
    {
        public Guid ComplaintId { get; set; }
        public Guid Complainant { get; set; }
        public string TicketNumber { get; set; }
        public DateTime Createdon { get; set; }
        public string Topic { get; set; }
        public int StatusCode { get; set; }
        public string Response { get; set; }
        public string Reasons { get; set; }
        public int AccusedType { get; set; }
        public int ReferTo { get; set; }
    }
    public class BaseComplaintListVm
    {
        public BaseComplaintListVm()
        {
            Complaints = new List<BaseComplaint>();
        }
        public int AllComplaintsCount { get; set; }
        public int CurrentComplaintsCount { get; set; }
        public IList<BaseComplaint> Complaints { get; set; }
    }
    public class ComplaintResult
    {
        public Guid complaintId { get; set; }
        public string TicketNumber { get; set; }
    }
}
