using System;
using System.Collections.Generic;
using System.Text;

namespace Behsa.Parliament.Test.ViewModels
{
    public class StateListVm
    {
        public StateListVm()
        {
            StatesVm = new List<StateVm>();
        }
        public int AllStateCount { get; set; }
        public int CurrentStateCount { get; set; }
        public IList<StateVm> StatesVm { get; set; }
    }

    public class StateVm
    {
        public Guid StateId { get; set; }
        public string StateName { set; get; }
        public string StateCode { set; get; }
    }
}
