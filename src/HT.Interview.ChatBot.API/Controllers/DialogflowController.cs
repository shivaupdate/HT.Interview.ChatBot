using AutoMapper;
using Google.Cloud.Dialogflow.V2;
using HT.Framework.MVC;
using HT.Interview.ChatBot.API.DTO.Response;
using HT.Interview.ChatBot.Common.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Google.Cloud.Dialogflow.V2.Intent.Types;
using static Google.Cloud.Dialogflow.V2.Intent.Types.Message.Types;

namespace HT.Interview.ChatBot.API.Controllers
{
    /// <inheritdoc />
    /// <summary>
    /// Dialogflow Controller
    /// </summary>
    [Route("api/v1/dialogflow")]
    public class DialogflowController : ApiControllerBase
    {
        #region Fields

        private readonly IDialogflowService _dialogflowService;
        private readonly IMapper _mapper;

        #endregion

        #region Public Functions

        /// <inheritdoc />
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="factory"></param>
        public DialogflowController(IChatBotDataFactory factory)
        {
            _dialogflowService = factory.GetDialogflowService();
            _mapper = factory.GetMapperService();
        }

        /// <summary>
        /// Get many async
        /// </summary>
        /// <returns></returns>
        [HttpGet(Common.Constants.GetMany)]
        public async Task<ActionResult> GetManyAsync()
        {
            return await GetResponseAsync(async () => (await _dialogflowService.GetIntentsAsync())
                .GetMappedResponse<IEnumerable<Common.Entities.Intent>, IEnumerable<IntentResponse>>(_mapper));
        }

        /// <summary>
        /// Create async
        /// </summary>
        /// <returns></returns>
        [HttpPost(Common.Constants.Create)]
        public async Task CreateAsync()
        {
            try
            {
               
                IEnumerable<IntentResponse> intentList =
                    (await _dialogflowService.GetIntentsAsync()).GetMappedResponse<IEnumerable<Common.Entities.Intent>, IEnumerable<IntentResponse>>(_mapper);

                string previousIntentName =string.Empty;

                if (intentList.Any())
                {
                    IntentsClient client = IntentsClient.Create();
                    foreach (IntentResponse intentResponse in intentList)
                    {
                        Intent intent = new Intent();


                        intent.DefaultResponsePlatforms.Add(Platform.ActionsOnGoogle);
                        intent.DisplayName = intentResponse.DisplayName;
                        intent.Messages.Add(AddIntentDefault(intentResponse.Text));
                         

                        if (intentResponse.IntentTrainingPhraseResponse.Any())
                        {
                            foreach (IntentTrainingPhraseResponse trainingPhrase in intentResponse.IntentTrainingPhraseResponse)
                            {
                                intent.TrainingPhrases.Add(AddIntentTrainingPhrase(trainingPhrase));
                            }
                        }

                        if (intentResponse.IntentParameterResponse.Any())
                        {
                            foreach (IntentParameterResponse parameter in intentResponse.IntentParameterResponse)
                            {
                                intent.Parameters.Add(AddIntentParameter(parameter));
                            }
                        }

                        if (intentResponse.IntentSuggestionResponse.Any())
                        {
                            foreach (IntentSuggestionResponse suggestion in intentResponse.IntentSuggestionResponse)
                            {
                                intent.Messages.Add(AddIntentSuggestion(suggestion.Title));
                            }
                        }

                        //if (intentResponse.InputContextNames != null)
                        //{
                        //    FollowupIntentInfo followupIntentInfo = new FollowupIntentInfo()
                        //    {
                        //        FollowupIntentName = "projects/ht-interview-chatbot/agent/intents/" + intentResponse.InputContextNames
                        //    };
                        //    intent.ParentFollowupIntentName = "projects/ht-interview-chatbot/agent/intents/" + previousIntentName; 
                        //    intent.FollowupIntentInfo.Add(followupIntentInfo);
                        //}
                        //intent.ResetContexts = false;
                        //intent.Action = "";
                        
                        Intent newIntent = client.CreateIntent(parent: new ProjectAgentName("ht-interview-chatbot"), intent: intent);
                        previousIntentName = newIntent.Name;
                        var result = newIntent.OutputContexts;
                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
        }

        /// <summary>
        /// Add intent default
        /// </summary>
        /// <param name="defaultResponse"></param>
        /// <returns></returns>
        private Message AddIntentDefault(string defaultResponse)
        {
            Text text = new Text();
            text.Text_.Add(defaultResponse);
            Message message = new Message()
            {
                Text = text
            };
            return message;
        }

        /// <summary>
        /// Add intent training phrase
        /// </summary>
        /// <param name="tp"></param>
        /// <returns></returns>
        private TrainingPhrase AddIntentTrainingPhrase(IntentTrainingPhraseResponse tp)
        {
            TrainingPhrase.Types.Part part = new TrainingPhrase.Types.Part()
            {
                Text = tp.Text

            };

            if (tp.EntityType != null)
            {
                part.EntityType = tp.EntityType;
            }

            TrainingPhrase trainingPhrase = new TrainingPhrase();
            trainingPhrase.Parts.Add(part);
            return trainingPhrase;
        }

        /// <summary>
        /// Add intent parameter
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        private Parameter AddIntentParameter(IntentParameterResponse param)
        {
            return new Parameter()
            {
                Mandatory = param.Mandatory,
                DisplayName = param.DisplayName,
                EntityTypeDisplayName = param.EntityTypeDisplayName,
                Value = param.Value,
                IsList = param.IsList
            };
        }

        /// <summary>
        /// Add intent suggestion
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        private Message AddIntentSuggestion(string title)
        {
            Suggestion suggestion = new Suggestion
            {
                Title = title
            };

            Suggestions suggestions = new Suggestions();
            suggestions.Suggestions_.Add(suggestion);

            Message message = new Message()
            {
                Suggestions = suggestions
            };

            return message;
        }

        #endregion
    }
}
