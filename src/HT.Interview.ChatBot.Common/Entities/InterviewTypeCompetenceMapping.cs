using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HT.Interview.ChatBot.Common.Entities
{
    public class InterviewTypeCompetenceMapping
    {
        [Required]
        public int InterviewTypeId { get; set; }

        [Required]
        public int CompetenceId { get; set; }

        [Required]
        public string CreatedBy { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
