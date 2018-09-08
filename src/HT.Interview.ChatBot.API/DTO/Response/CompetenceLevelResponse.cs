using System;

namespace HT.Interview.ChatBot.API.DTO.Response
{
    /// <summary>
    /// CompetenceLevel response
    /// </summary>
    public class CompetenceLevelResponse
    {
        
        public int Id { get; set; }

        
        public string Name { get; set; }

        
        public string CreatedBy { get; set; }

        
        public DateTime CreatedOn { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

    }
}
