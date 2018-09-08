using System;

namespace HT.Interview.ChatBot.API.DTO.Response
{
    /// <summary>
    /// Candidate response
    /// </summary>
    public class CandidateResponse
    {
        
        public int Id { get; set; }


        public string FirstName { get; set; }
      
        public string LastName { get; set; }
       
        public string Email { get; set; }
      
        public int GenderId { get; set; }
    
        public string Mobile { get; set; }
        


        public string CreatedBy { get; set; }

        
        public DateTime CreatedOn { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

    }
}
