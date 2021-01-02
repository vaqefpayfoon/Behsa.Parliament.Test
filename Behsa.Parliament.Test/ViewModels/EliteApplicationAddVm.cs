using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Behsa.Parliament.Test.ViewModels
{
    public class EliteApplicationAddVm
    {
        [Required]
        public Guid ContactId { get; set; }
        [Required]
        public Guid ExpertiseAreaId { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string ExperimentalRecords { get; set; }
        [Required]
        public string ScientificResearchRecords { get; set; }
    }
}
