using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HT.Interview.ChatBot.API.DTO.Response
{
    public class InterviewDetailResponse
    {
        /// <summary>
        /// Get or sets the ID
        /// </summary>
        /// <value>
        /// The ID
        /// </value> 
        public int Id { get; set; }

        /// <summary>
        /// Get or sets the CandidateId
        /// </summary>
        /// <value>
        /// The CandidateId
        /// </value> 
        public int UserId { get; set; }

        /// <summary>
        /// Get or sets the ProfileAppliedFor
        /// </summary>
        /// <value>
        /// The ProfileAppliedFor
        /// </value> 
        public string ProfileAppliedFor { get; set; }

        /// <summary>
        /// Get or sets the BotResponse
        /// </summary>
        /// <value>
        /// The BotResponse
        /// </value> 
        public string BotResponse { get; set; }

        /// <summary>
        /// Get or sets the CandidateReponse
        /// </summary>
        /// <value>
        /// The CandidateReponse
        /// </value> 
        public string UserResponse { get; set; }

        /// <summary>
        /// Get or sets the ExpectedAnswer
        /// </summary>
        /// <value>
        /// The ExpectedAnswer
        /// </value> 
        public string ExpectedAnswer { get; set; }

        /// <summary>
        /// Get or sets the AllocatedTime
        /// </summary>
        /// <value>
        /// The AllocatedTime
        /// </value> 
        public int AllocatedTime { get; set; }

        /// <summary>
        /// Get or sets the TimeTaken
        /// </summary>
        /// <value>
        /// The TimeTaken
        /// </value> 
        public int TimeTaken { get; set; }

        /// <summary>
        /// Get or sets the Remark
        /// </summary>
        /// <value>
        /// The Remark
        /// </value> 
        public string Remark { get; set; }
    }
}
