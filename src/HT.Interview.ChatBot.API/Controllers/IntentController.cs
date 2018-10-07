using AutoMapper;
using Google.Cloud.Dialogflow.V2;
using Google.Protobuf.WellKnownTypes;
using HT.Framework.MVC;
using HT.Interview.ChatBot.Common.Contracts;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Google.Cloud.Dialogflow.V2.Intent.Types;
using static Google.Cloud.Dialogflow.V2.Intent.Types.Message.Types;
using Model = HT.Interview.ChatBot.Common.Entities;

namespace HT.Interview.ChatBot.API.Controllers
{
    /// <inheritdoc />
    /// <summary>
    /// Intent Controller
    /// </summary>
    [Route("api/v1/intent")]
    public class IntentController : ApiControllerBase
    {
        #region Fields

        private readonly IIntentService _intentService;
        private readonly IMapper _mapper;

        #endregion

        #region Public Functions

        /// <inheritdoc />
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="factory"></param>
        public IntentController(IChatBotDataFactory factory)
        {
            _intentService = factory.GetIntentService();
            _mapper = factory.GetMapperService();
        }

        /// <summary>
        /// Get many async
        /// </summary>
        /// <returns></returns>
        [HttpGet(Common.Constants.GetMany)]
        public async Task<ActionResult> GetManyAsync()
        {
            return await GetResponseAsync(async () => (await _intentService.GetIntentsAsync())
                .GetMappedResponse<IEnumerable<Model.Intent>, IEnumerable<Model.Intent>>(_mapper));
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
                IEnumerable<Model.Intent> intentList =
                    (await _intentService.GetIntentsAsync()).GetMappedResponse<IEnumerable<Model.Intent>, IEnumerable<Model.Intent>>(_mapper);

                if (intentList.Any())
                {
                    IntentsClient client = IntentsClient.Create();
                    foreach (Model.Intent intentResponse in intentList)
                    {
                        Intent intent = new Intent();
                        intent.DefaultResponsePlatforms.Add(Platform.ActionsOnGoogle);
                        intent.DisplayName = intentResponse.DisplayName;
                        intent.Messages.Add(AddIntentDefault(intentResponse.Text));
                        intent.Messages.Add(AddCustomPayload(intentResponse.AllocatedTime));
                        
                        if (intentResponse.ParentIntentId != null)
                        {
                            intent.ParentFollowupIntentName = intentList.Where(x => x.Id == intentResponse.ParentIntentId).FirstOrDefault().DialogflowGeneratedName;
                        }

                        if (intentResponse.InputContext != null)
                        {
                            foreach (string inputContext in intentResponse.InputContext.Split(','))
                            {
                                intent.InputContextNames.Add(AddIntentInputContext(inputContext));
                            }
                        }

                        if (intentResponse.OutputContext != null)
                        {
                            foreach (string outputContext in intentResponse.OutputContext.Split(','))
                            {
                                intent.OutputContexts.Add(AddIntentOutputContext(outputContext));
                            }
                        }

                        if (intentResponse.IntentTrainingPhrase.Any())
                        {
                            foreach (Model.IntentTrainingPhrase trainingPhrase in intentResponse.IntentTrainingPhrase)
                            {
                                intent.TrainingPhrases.Add(AddIntentTrainingPhrase(trainingPhrase));
                            }
                        }

                        if (intentResponse.IntentParameter.Any())
                        {
                            foreach (Model.IntentParameter parameter in intentResponse.IntentParameter)
                            {
                                intent.Parameters.Add(AddIntentParameter(parameter));
                            }
                        }

                        if (intentResponse.IntentSuggestion.Any())
                        {
                            intent.Messages.Add(AddIntentSuggestion(intentResponse.IntentSuggestion.Select(x => x.Title).ToList()));
                        }

                        intent = client.CreateIntent(parent: new ProjectAgentName("ht-interview-chatbot"), intent: intent);
                        intentResponse.DialogflowGeneratedIntentId = intent.IntentName.IntentId;
                        intentResponse.DialogflowGeneratedName = intent.Name;
                        intentResponse.DialogflowGeneratedIntent = JsonConvert.SerializeObject(intent);
                        await _intentService.UpdateIntentsAsync(_mapper.Map<Model.Intent>(intentResponse));
                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
        }

        /// <summary>
        /// Add intent input context
        /// </summary>
        /// <param name="inputContextName"></param>
        /// <returns></returns>
        private string AddIntentInputContext(string inputContextName)
        {

            return "projects/ht-interview-chatbot/agent/sessions/-/contexts/" + inputContextName;
        }

        /// <summary>
        /// Add intent output context
        /// </summary>
        /// <param name="outputContextName"></param>
        /// <returns></returns>
        private Context AddIntentOutputContext(string outputContextName)
        {
            Context context = new Context()
            {
                LifespanCount = 2,
                Name = "projects/ht-interview-chatbot/agent/sessions/-/contexts/" + outputContextName
            };
            return context;
        }

        /// <summary>
        /// Add default intent
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
        /// Add custom payload
        /// </summary>
        /// <param name="allocatedTime"></param>
        /// <returns></returns>
        private Message AddCustomPayload(int allocatedTime)
        {
            Message message = new Message
            {
                Payload = new Struct()
            };
            message.Payload.Fields.Add("allocatedTime", new Value { NumberValue = allocatedTime });
            return message;
        }

        /// <summary>
        /// Add intent training phrase
        /// </summary>
        /// <param name="tp"></param>
        /// <returns></returns>
        private TrainingPhrase AddIntentTrainingPhrase(Model.IntentTrainingPhrase tp)
        {
            TrainingPhrase.Types.Part part = new TrainingPhrase.Types.Part()
            {
                Text = tp.Text
            };

            if (tp.EntityType != null)
            {
                part.EntityType = tp.EntityType;
            }
            if (tp.Alias != null)
            {
                part.Alias = tp.Alias;
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
        private Parameter AddIntentParameter(Model.IntentParameter param)
        {
            Parameter parameter = new Parameter()
            {
                Mandatory = param.Mandatory,
                DisplayName = param.DisplayName,
                EntityTypeDisplayName = param.EntityTypeDisplayName,
                Value = param.Value,
                IsList = param.IsList
            };
            if (param.Prompt != null)
            {
                parameter.Prompts.Add(param.Prompt);
            }
            return parameter;
        }

        /// <summary>
        /// Add intent suggestion
        /// </summary>
        /// <param name="titles"></param>
        /// <returns></returns>
        private Message AddIntentSuggestion(List<string> titles)
        {
            Suggestions suggestions = new Suggestions();

            foreach (string title in titles)
            {
                Suggestion suggestion = new Suggestion
                {
                    Title = title
                };

                suggestions.Suggestions_.Add(suggestion);
            }

            Message message = new Message()
            {
                Suggestions = suggestions
            };

            return message;
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
