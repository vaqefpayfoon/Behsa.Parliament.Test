using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Behsa.Parliament.Test.ViewModels
{
    public class IncidentAddVm
    {
        public Guid? ContactId { get; set; }//در صورتی که کانتکت ای دی پر باشد اینسیدنت را برای کانتکت درغیر این صورت برای اکانت ثبت میکند
        public Guid? AccountId { get; set; }
        public int RequestType { get; set; }//2 = namayande , 1 = raees majles 
        public Guid UserId { get; set; } // کلید نماینده
        [Required]
        public string IncidentTitle { set; get; }
        [Required]
        public Guid RequestGroupId { get; set; }
        [Required]
        public Guid RequestSubGroupId { get; set; }
        [Required]
        public string Description { set; get; }
        public Guid ConstituencyId { get; set; }
        public Guid StateId { get; set; }
    }
}
