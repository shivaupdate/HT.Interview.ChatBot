using System;

namespace HT.Interview.ChatBot.API.DTO.Response
{
    /// <summary>
    /// InterviewTypeCompetenceMapping response
    /// </summary>
    public class InterviewTypeCompetenceMappingResponse
    {

        public int InterviewTypeId { get; set; }

      
        public int CompetenceId { get; set; }



        public string CreatedBy { get; set; }

        
        public DateTime CreatedOn { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

    }
}
