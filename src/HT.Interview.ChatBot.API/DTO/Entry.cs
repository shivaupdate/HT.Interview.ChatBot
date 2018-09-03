﻿using System.Collections.Generic;

namespace HT.Interview.ChatBot.API.DTO
{
    /// <summary>
    /// Entry
    /// </summary>
    public class Entry
    {
        /// <summary>
        /// For mapping entities: a canonical name to be used in place of synonyms.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Array of strings that can include simple strings (for words and phrases) or references to other entites (with or without aliases).
        /// </summary>
        public List<string> Synonyms { get; set; }
    }
}
