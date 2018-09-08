using System;

namespace HT.Interview.ChatBot.API.DTO.Response
{
    /// <summary>
    /// AccessMatrix response
    /// </summary>
    public class AccessMatrixResponse
    {
        
        public int Id { get; set; }



        public int RoleId { get; set; }


   
        public int MenuId { get; set; }


        public string CreatedBy { get; set; }

        
        public DateTime CreatedOn { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

    }
}
