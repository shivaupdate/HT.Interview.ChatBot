using System;

namespace HT.Interview.ChatBot.API.DTO.Response
{
    /// <summary>
    /// Attachment response
    /// </summary>
    public class AttachmentResponse
    {
        
        public int Id { get; set; }


        public int CandidateId { get; set; }
     


        public string ResumeFilePath { get; set; }
   

        public string GestureRecordingFilePath { get; set; }
 



        public string CreatedBy { get; set; }

        
        public DateTime CreatedOn { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

    }
}
