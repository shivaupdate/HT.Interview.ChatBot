using System;
using System.Collections.Generic;
using System.Text;

namespace HT.Interview.ChatBot.Common.Entities
{
    public class Dashboard
    {
        /// <summary>
        /// Get or sets the ID
        /// </summary>
        /// <value>
        /// The ID
        /// </value>
        public long Id { get; set; }

        /// <summary>
        /// Get or sets the Year
        /// </summary>
        /// <value>
        /// The Year
        /// </value> 
        public int Year { get; set; }

        /// <summary>
        /// Get or sets the Month
        /// </summary>
        /// <value>
        /// The Month
        /// </value> 
        public string Month { get; set; }

        /// <summary>
        /// Get or sets the Competence
        /// </summary>
        /// <value>
        /// The Competence
        /// </value> 
        public string Competence { get; set; }

        /// <summary>
        /// Get or sets the Count
        /// </summary>
        /// <value>
        /// The Count
        /// </value> 
        public int Count { get; set; }
    }
}
