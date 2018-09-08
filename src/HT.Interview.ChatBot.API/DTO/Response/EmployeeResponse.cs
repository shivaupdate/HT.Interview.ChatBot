using System;

namespace HT.Interview.ChatBot.API.DTO.Response
{
    /// <summary>
    /// Employee response
    /// </summary>
    public class EmployeeResponse
    {
        
        public int Id { get; set; }


        public int EmployeeNo { get; set; }
      
        public string UserName { get; set; }
       
        public int RoleId { get; set; }


        public string CreatedBy { get; set; }

        
        public DateTime CreatedOn { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

    }
}
