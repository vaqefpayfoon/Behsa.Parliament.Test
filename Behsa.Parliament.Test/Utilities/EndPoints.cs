using System;
using System.Collections.Generic;
using System.Text;

namespace Behsa.Parliament.Test.Utilities
{
    public static class EndPoints
    {
        private static string LocalHost = "http://localhost:60293/";
        private static string Dev = "http://172.18.60.4:8097/";
        private static string DevStable = "http://172.18.60.4:8087/";
        private static string Test = "https://zrmctest.parliran.ir:448/";
        
        public static string BaseUrl = Test;
        public static string Contacts = "contacts";
        public static string Accounts = "accounts";
        public static string Incidents = "incidents";
        public static string Documents = "documents";
        public static string EliteApplication = "eliteapplications";
        public static string States = "states";
        public static string ExpertiesAreas = "expertiesareas";
        public static string RequestGroups = "requestGroups";
        public static string RequestSubGroups = "requestSubGroups";
        public static string Constituencies = "constituencies";
        public static string Requests = "requests";
        public static string Complaint = "complaints";
        public static string ComplaintContact = "complaints/contactComplaint";
        public static string ComplaintAccount = "complaints/accountComplaint";
        public static string ComplaintOrganization = "complaints/organizationComplaint";
        public static string Users = "users";
    }
}
