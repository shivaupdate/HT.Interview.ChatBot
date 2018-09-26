using System;
using System.Collections.Generic;
using System.Text;

namespace HT.Interview.ChatBot.Common.Entities
{
    public class Dashboard
    {
        public long Id { get; set; }
        public int Year { get; set; }
        public string Month { get; set; }
        public string Competence { get; set; }
        public int Count { get; set; }
    }
}
