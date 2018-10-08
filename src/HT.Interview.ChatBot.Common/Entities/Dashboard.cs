namespace HT.Interview.ChatBot.Common.Entities
{
    /// <summary>
    /// Dashboard model
    /// </summary>
    public class Dashboard
    {
        /// <summary>
        /// Get or sets the Id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets the category label
        /// </summary>
        public string InterviewMonth { get; set; }

        /// <summary>
        /// Gets or sets the data set label
        /// </summary>
        public string TechnologyStackDisplayName { get; set; }

        /// <summary>
        /// Get or sets the data set
        /// </summary>
        public int MonthlyInterviewCount { get; set; } 
    } 
}
