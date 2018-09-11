using HT.Framework;
using HT.Framework.Contracts;
using HT.Interview.ChatBot.Common.Contracts;
using HT.Interview.ChatBot.Common.DTO;
using HT.Interview.ChatBot.Common.Entities;
using HT.Interview.ChatBot.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HT.Interview.ChatBot.Services
{
    /// <inheritdoc />
    /// <summary>
    /// Candidate Service
    /// </summary>
    public class CandidateService : ICandidateService
    {
        #region Fields

        private readonly IChatBotDataContext _chatbotDataContext;
        private readonly IContentService _resourceService;

        #endregion

        #region Public Functions

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="factory"></param>
        /// <param name="chatbotDataContext"></param>
        public CandidateService(IChatBotDataFactory factory, IChatBotDataContext chatbotDataContext)
        {
            _chatbotDataContext = chatbotDataContext;
            _resourceService = factory.GetResourceService(Common.Constants.ResourceComponent);
        }

        public async Task<Response> AddCandidateAsync(Candidate candidate)
        {
            try
            {
                _chatbotDataContext.Candidate.Add(candidate);
                await _chatbotDataContext.SaveChangesAsync();
                return Response.Ok();
            }
            catch (System.Exception ex)
            {
                ex.Message.ToString();
                return null;
            }
        }

        public async Task<Response> DeleteCandidateAsync(Candidate candidate)
        {
            try
            {
                _chatbotDataContext.Candidate.Remove(candidate);
                await _chatbotDataContext.SaveChangesAsync();
                return Response.Ok();
            }
            catch (System.Exception ex)
            {
                ex.Message.ToString();
                return null;
            }
        }

        #region Get Candidates

        /// <summary>
        /// Get Candidates async
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="createdBy"></param>
        /// <returns></returns>
        public async Task<Response<IEnumerable<Candidate>>> GetCandidatesAsync(Candidate obj)
        {
            IEnumerable<Candidate> Candidates = await _chatbotDataContext.Candidate.ToListAsync();
            // TODO: Search Candidates result list against search parameters
            return Response.Ok(Candidates);
        }

        public async Task<Response> UpdateCandidateAsync(Candidate candidate)
        {
            try
            {
                _chatbotDataContext.Candidate.Update(candidate);
                await _chatbotDataContext.SaveChangesAsync();
                return Response.Ok();
            }
            catch (System.Exception ex)
            {
                ex.Message.ToString();
                return null;
            }
        }

        #endregion

        #endregion
    }
}