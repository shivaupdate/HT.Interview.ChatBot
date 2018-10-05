using AutoMapper;
using HT.Framework.MVC;
using HT.Interview.ChatBot.API.DTO.Response;
using HT.Interview.ChatBot.Common.Contracts;
using HT.Interview.ChatBot.Common.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HT.Interview.ChatBot.API.Controllers
{
    /// <inheritdoc />
    /// <summary>
    /// Competence controller
    /// </summary>
    [Route("api/v1/competence")]
    public class CompetenceController : ApiControllerBase
    {
        #region Fields

        private readonly ICompetenceService _competenceService;
        private readonly IMapper _mapper;

        #endregion

        #region Public Functions

        /// <inheritdoc />
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="factory"></param>
        public CompetenceController(IChatBotDataFactory factory)
        {
            _competenceService = factory.GetCompetenceService();
            _mapper = factory.GetMapperService();
        }

        /// <summary>
        /// Get many async
        /// </summary>
        /// <returns></returns>
        [HttpGet(Common.Constants.GetMany)]
        public async Task<ActionResult> GetManyAsync([FromQuery] int? id, [FromQuery]string name, [FromQuery] string createdyBy)
        {
            return await GetResponseAsync(async () => (await _competenceService.GetCompetencesAsync(id, name, createdyBy))
                .GetMappedResponse<IEnumerable<Competence>, IEnumerable<CompetenceResponse>>(_mapper));
        }
         
        #endregion
    }
}
