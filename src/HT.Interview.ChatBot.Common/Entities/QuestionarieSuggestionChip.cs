using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HT.Interview.ChatBot.Common.Entities
{
    public class QuestionarieSuggestionChip
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int QuestionarieId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string CreatedBy { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
