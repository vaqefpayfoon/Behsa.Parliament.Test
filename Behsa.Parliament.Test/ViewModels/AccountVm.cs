using System;
using System.Collections.Generic;
using System.Text;

namespace Behsa.Parliament.Test.ViewModels
{
    public class AccountVm
    {
        public Guid AccountId { get; set; }
        public string AccountName { get; set; }

        public string MobilePhone { get; set; }

        public string CorporateBranding { get; set; }
        public string LicensingReference { get; set; }
        public Guid StateId { get; set; }
        public string StateName { get; set; }
        public string CityName { get; set; }
        public string RegisterationNumber { get; set; }
        public string NationalId { get; set; }
        public string ActivityType { get; set; }
        public string MainActivity { get; set; }
        public Guid PrimaryContactId { get; set; }
        public string PrimaryContactName { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
    }
}
