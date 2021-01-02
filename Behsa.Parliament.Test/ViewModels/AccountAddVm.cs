using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Behsa.Parliament.Test.ViewModels
{
    public class AccountAddVm
    {
        [Required]
        [MinLength(1)]
        public string AccountName { get; set; }
        [Required]
        [MinLength(1)]
        public string CorporateBranding { get; set; }
        public string LicensingReference { get; set; }
        public string ActivityType { get; set; }
        public string RegistrationNumber { get; set; }
        public string PrimaryContactNationalId { get; set; }
        public string MainActivity { get; set; }

        public string Telephone { get; set; }

        [Required]
        [MinLength(1)]
        public string CityName { get; set; }
        [Required]
        [MinLength(1)]
        public Guid? StateId { get; set; }
        public Guid ContactId { get; set; }
        //for contact
        [Required]
        [MinLength(1)]
        public string PrimaryContactMobilePhone { get; set; }
        [Required]
        [MinLength(1)]
        public string PrimaryContactFirstName { get; set; }
        [Required]
        [MinLength(1)]
        public string PrimaryContactLastName { get; set; }
        [Required]
        [MinLength(1)]
        public string NationalId { get; set; }
        public string Address { get; set; }
    }
}
