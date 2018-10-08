using System.Collections.Generic;

namespace HT.Interview.ChatBot.Common.DTO
{
    /// <summary>
    /// Dashboard response
    /// </summary>
    public class DashboardResponse
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public DashboardResponse()
        { 
            ChartLabel = new List<string>();
            ChartDataSet = new List<ChartDataSet>();
        }

        /// <summary>
        /// Gets or sets the chart type
        /// </summary>
        public string ChartType { get; set; }

        /// <summary>
        /// Get or sets the chart labels
        /// </summary>
        public List<string> ChartLabel { get; set; } 

        /// <summary>
        /// Gets or sets char data set
        /// </summary>
        public List<ChartDataSet> ChartDataSet { get; set; }
    }

    /// <summary>
    /// Char data set
    /// </summary>
    public class ChartDataSet
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public ChartDataSet()
        {
            Data = new List<int>(); 
        }

        /// <summary>
        /// Gets or sets the lable
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// Gets or sets the 
        /// </summary>
        public List<int> Data { get; set; }
    }
}
