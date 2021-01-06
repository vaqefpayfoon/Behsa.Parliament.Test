using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Behsa.Parliament.Test.ViewModels
{
    public class ComplaintAddAccountVm
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
        public string AccountName { get; set; }
        public string RegistrationNumber { get; set; }
        public string AccountActivityType { get; set; }
        public string AccountBusinessphone { get; set; }
        public string AccountNationalId { get; set; }
        public string AccountAddress { get; set; }
        public string CorporateBranding { get; set; }
    }
}