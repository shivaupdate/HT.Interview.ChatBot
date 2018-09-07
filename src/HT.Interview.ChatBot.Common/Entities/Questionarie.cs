using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HT.Interview.ChatBot.Common.Entities
{
    public class Questionarie
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int CompetenceId { get; set; }

        [Required]
        public int CompetenceLevelId { get; set; }

        [Required]
        public string Question { get; set; }

        [Required]
        public int AllocatedTime { get; set; }

        [Required]
        public string CreatedBy { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
