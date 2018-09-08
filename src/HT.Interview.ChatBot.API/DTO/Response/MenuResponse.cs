using System;

namespace HT.Interview.ChatBot.API.DTO.Response
{
    /// <summary>
    /// Menu response
    /// </summary>
    public class  MenuResponse
    {
        
        public int Id { get; set; }


        public string Options { get; set; }

        public string CreatedBy { get; set; }

        
        public DateTime CreatedOn { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

    }
}
