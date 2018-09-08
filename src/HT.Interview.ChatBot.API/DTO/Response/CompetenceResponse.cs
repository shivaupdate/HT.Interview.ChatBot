using System;

namespace HT.Interview.ChatBot.API.DTO.Response
{
    /// <summary>
    /// Competence response
    /// </summary>
    public class CompetenceResponse
    {
        
        public int Id { get; set; }

        
        public string Name { get; set; }

        
        public string CreatedBy { get; set; }

        
        public DateTime CreatedOn { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

    }
}
