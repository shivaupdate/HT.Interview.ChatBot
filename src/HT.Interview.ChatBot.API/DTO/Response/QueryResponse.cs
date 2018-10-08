﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace HT.Interview.ChatBot.API.DTO.Response
{
    /// <summary>
    /// QueryResponse
    /// </summary>
    [Serializable]
    public class QueryResponse : ResponseBase
    {
        #region Public Properties

        /// <summary>
        /// Result
        /// </summary>
        public QueryResult Result { get; set; }

        #endregion
    }

    /// <summary>
    /// QueryResult
    /// </summary>
    [Serializable]
    public class QueryResult
    {
        #region Public Properties

        /// <summary>
        /// Dialogflow generated intent id
        /// </summary>
        public string DialogflowGeneratedIntentId { get; set; }

        /// <summary>
        /// Interview id
        /// </summary>
        public int InterviewId { get; set; }

        /// <summary>
        /// Source of the answer. Could be "agent" if the response was retrieved from the agent. 
        /// </summary>
        public string Source { get; set; }

        /// <summary>
        /// The query that was used to produce this result.
        /// </summary>
        public string ResolvedQuery { get; set; }

        /// <summary>
        /// An action to take.
        /// </summary>
        public string Action { get; set; }

        /// <summary>
        /// true if the triggered intent has required parameters and not all the required parameter values have been collected
        /// false if all required parameter values have been collected or if the triggered intent doesn't containt any required parameters
        /// </summary>
        public bool ActionIncomplete { get; set; }

        /// <summary>
        /// Parameters to be used by the action.
        /// </summary>
        public Dictionary<string, object> Parameters { get; set; }

        /// <summary>
        /// Array of context objects with the fields "name", "parameters", "lifespan".
        /// </summary>
        public Context[] Contexts { get; set; }

        /// <summary>
        /// Data about fulfillment, speech, structured fulfillment data, etc.
        /// </summary>
        public FulfillmentResponse Fulfillment { get; set; }

        /// <summary>
        /// Matching score for the intent
        /// </summary>
        public float Score { get; set; }

        /// <summary>
        /// Contains data on intents and contexts.
        /// </summary>
        public MetadataResponse Metadata { get; set; }

        #endregion

        #region Public Methods

        /// <summary>
        /// Get context by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Context GetContextByName(string name)
        {
            if (Contexts == null || Contexts.Count() == 0)
            {
                throw new NullReferenceException("Contexts is null or empty.");
            }

            var context = Contexts.Where(x => x.Name == name).FirstOrDefault();

            if (context == null)
            {
                throw new KeyNotFoundException($"Context '{name}' not found.");
            }

            return context;
        }

        /// <summary>
        /// Get parameter value in context (name) by key
        /// </summary>
        /// <param name="name"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public object GetContextParameterValueByNameKey(string name, string key)
        {
            var context = GetContextByName(name);  

            if (!context.Parameters.TryGetValue(key, out object result))
            {
                throw new KeyNotFoundException($"Context '{name}' and parameter key '{key}' not found.");
            }

            return result;
        }

        /// <summary>
        /// Get parameter value by key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public object GetParameterValueByKey(string key)
        {
            if (Contexts == null || Contexts.Count() == 0)
            {
                throw new NullReferenceException("Contexts is null or empty.");
            } 

            object result = null; 

            foreach (Context context in Contexts)
            {
                if (context.Parameters.TryGetValue(key, out result))
                {
                    return result;
                }
            }
            throw new KeyNotFoundException($"Parameter '{key}' not found.");
        }

        #endregion
    }
}
