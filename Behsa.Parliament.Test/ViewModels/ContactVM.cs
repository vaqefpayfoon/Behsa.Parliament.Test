using System;
using System.Collections.Generic;
using System.Text;

namespace Behsa.Parliament.Test.ViewModels
{
    public class ContactVm
    {
        public Guid ContactId { get; set; }
        public Guid? AccountId { get; set; }
        public string AccountName { get; set; }
        public string FullName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Telephone { get; set; }
        public string MobilePhone { get; set; }
        public string NationalId { get; set; }
        public string FathersName { get; set; }
        public string Address { get; set; }
        //public DateTime Birthday { get; set; }
        public Guid? StateId { get; set; }
        public string StateName { get; set; }
        public string CityName { get; set; }
        public string bhs_LTN_Complaint { get; set; }
        public string bhs_LTN_Elite { get; set; }
        public string bhs_LTN_Incident_S { get; set; }
        public string bhs_LTN_Incident_L { get; set; }
    }
}
