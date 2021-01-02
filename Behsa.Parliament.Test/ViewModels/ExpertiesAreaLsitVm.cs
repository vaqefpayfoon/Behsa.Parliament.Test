using System;
using System.Collections.Generic;
using System.Text;

namespace Behsa.Parliament.Test.ViewModels
{
    public class ExpertiesAreaLsitVm
    {
        public ExpertiesAreaLsitVm()
        {
            ExpertiesAreasVm = new List<ExpertiesAreaVm>();
        }
        public int AllExpertiesAreaCount { get; set; }
        public int CurrentExpertiesAreaCount { get; set; }
        public IList<ExpertiesAreaVm> ExpertiesAreasVm { get; set; }
    }
    public class ExpertiesAreaVm
    {
        public Guid ExpertiesAreaId { get; set; }
        public string Name { get; set; }
    }
}
