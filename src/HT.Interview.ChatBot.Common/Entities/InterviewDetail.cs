using System;
using System.Collections.Generic;
using System.Text;

namespace HT.Interview.ChatBot.Common.Entities
{
    public class InterviewDetail
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
        public int CandidateId { get; set; }

        /// <summary>
        /// Get or sets the CandidateName
        /// </summary>
        /// <value>
        /// The CandidateName
        /// </value> 
        public string CandidateName { get; set; }

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
        public string CandidateReponse { get; set; }

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
