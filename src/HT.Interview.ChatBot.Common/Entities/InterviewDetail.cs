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
        /// Get or sets the user id
        /// </summary>
        /// <value>
        /// The UserId
        /// </value> 
        public int UserId { get; set; }

        /// <summary>
        /// Get or sets the BotResponse
        /// </summary>
        /// <value>
        /// The BotResponse
        /// </value> 
        public string BotResponse { get; set; }

        /// <summary>
        /// Get or sets the user response
        /// </summary>
        /// <value>
        /// The UserRseponse
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
    }
}
