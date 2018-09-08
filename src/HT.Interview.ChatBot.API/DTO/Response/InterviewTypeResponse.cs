using System;

namespace HT.Interview.ChatBot.API.DTO.Response
{
    /// <summary>
    /// InterviewType response
    /// </summary>
    public class InterviewTypeResponse
    {
        
        public int Id { get; set; }


        public string Type { get; set; }

        public string CreatedBy { get; set; }

        
        public DateTime CreatedOn { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

    }
}
