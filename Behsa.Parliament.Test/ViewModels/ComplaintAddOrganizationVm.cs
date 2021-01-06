using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Behsa.Parliament.Test.ViewModels
{
    public class ComplaintAddOrganizationVm
    {
        public Guid? AccountId { get; set; }
        public Guid? ContactId { get; set; }
        public DateTime Createdon { get; set; }
        [Required]
        public string Topic { get; set; }
        [Required]
        public string Reasons { get; set; }
        [Required]
        public int? ReferTo { get; set; }

        [Required]
        public string OrganName { get; set; }
        public string OrganAddress { get; set; }
        public string OrganBusinessPhone { get; set; }
        public string OrganActivityType { get; set; }
    }
}