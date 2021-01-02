using System;
using System.Collections.Generic;
using System.Text;

namespace Behsa.Parliament.Test.ViewModels
{
    public class RequestGroupListVm
    {
        public RequestGroupListVm()
        {
            RequestGroups = new List<RequestGroupVm>();
        }
        public int AllRquestGroupsCount { get; set; }
        public int CurrentRquestGroupsCount { get; set; }
        public IList<RequestGroupVm> RequestGroups { get; set; }
    }
    public class RequestGroupVm
    {
        public Guid RequestGroupId { get; set; }
        public string GroupCode { set; get; }
        public string GroupName { set; get; }
    }
}
