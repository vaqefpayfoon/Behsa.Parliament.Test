using System;

namespace Behsa.Parliament.Test.ViewModels
{
    public class EliteApplicationVm
    {
        public Guid EliteapplicationId { get; set; }
        public Guid ContactId { get; set; }
        public Guid ExpertiseAreaId { get; set; }
        public string ExpertiseAreaName { get; set; }
        public string ContactName { get; set; }
        public string Description { get; set; }
        public string ExperimentalRecords { get; set; }
        public string Name { get; set; }
        public string ScientificResearchRecords { get; set; }
        public string NationalId { get; set; }
        public string StatusCode { get; set; }
        public string TicketNumber { get; set; }
        public DateTime CreatedOn { get; set; }
    }
    public class EliteApplicationResult
    {
        public Guid EliteapplicationId { get; set; }
        public string TicketNumber { get; set; }
    }
}
