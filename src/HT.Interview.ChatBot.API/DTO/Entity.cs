using System.Collections.Generic;
using System.ComponentModel;

namespace HT.Interview.ChatBot.API.DTO
{
    /// <summary>
    /// The entity JSON object contains all information about an entity, including its ID, name, and entries.
    /// </summary>
    public class Entity
    {
        #region Public Properties

        /// <summary>
        /// A unique identifier for the entity.
        /// </summary>
        [DefaultValue(null)]
        public string Id { get; set; }

        /// <summary>
        /// The name of the entity.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// An array of entry objects, which contain reference values and synonyms.
        /// </summary>
        public List<Entry> Entries { get; set; }

        /// <summary>
        /// Indicates if the entity is a mapping or an enum type entity.
        /// </summary>
        [DefaultValue(false)]
        public bool IsEnum { get; set; }

        /// <summary>
        /// Indicates if the entity can be automatically expanded.
        /// </summary>
        [DefaultValue(false)]
        public bool AutomatedExpansion { get; set; }

        #endregion
    }
}
