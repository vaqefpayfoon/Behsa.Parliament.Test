using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Behsa.Parliament.Test.ViewModels
{
    public class ComplaintAddContactVm
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
        public string ContactName { get; set; }
        [Required]
        public string ContactLastName { get; set; }
        [Required]
        public string FathersName { get; set; }
        public string ContactNationalID { get; set; }
        public string ContactAddress { get; set; }
        public string ContactBusinessPhone { get; set; }
        public string Id { get; set; }//شماره شناسنامه

    }
}