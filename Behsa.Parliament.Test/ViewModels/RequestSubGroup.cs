using System;
using System.Collections.Generic;
using System.Text;

namespace Behsa.Parliament.Test.ViewModels
{
    public class RequestSubGroupListVm
    {
        public RequestSubGroupListVm()
        {
            RequestSubGroups = new List<RequestSubGroupVm>();
        }
        public int AllRquestSubGroupsCount { get; set; }
        public int CurrentRquestSubGroupsCount { get; set; }
        public IList<RequestSubGroupVm> RequestSubGroups { get; set; }
    }
    public class RequestSubGroupVm
    {
        public Guid RequestSubGroupId { get; set; }
        public Guid RequestGroupId { get; set; }
        public string RequestGroupName { get; set; }
        public string SubGroupCode { get; set; }
        public string SubGroupName { get; set; }
    }
}
