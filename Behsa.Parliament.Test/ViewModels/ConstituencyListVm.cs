using System;
using System.Collections.Generic;
using System.Text;

namespace Behsa.Parliament.Test.ViewModels
{
    public class ConstituencyListVm
    {
        public ConstituencyListVm()
        {
            Constituencies = new List<ConstituencyVm>();
        }
        public int AllConstituenciesCount { get; set; }
        public int CurrentConstituenciesCount { get; set; }
        public IList<ConstituencyVm> Constituencies { get; set; }
    }
    public class ConstituencyVm
    {
        public Guid ConstituencyId { get; set; }
        public string ConstituencyCode { get; set; }
        public string ConstituencyName { get; set; }
        public Guid StateId { get; set; }
        public string StateName { get; set; }
    }
}
