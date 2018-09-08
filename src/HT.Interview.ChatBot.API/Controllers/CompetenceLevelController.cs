using AutoMapper;
using HT.Framework.MVC;
using HT.Interview.ChatBot.API.DTO.Request;
using HT.Interview.ChatBot.API.DTO.Response;
using HT.Interview.ChatBot.Common.Contracts;
using HT.Interview.ChatBot.Common.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Model = HT.Interview.ChatBot.Common.DTO;

namespace HT.Interview.ChatBot.API.Controllers
{
    /// <inheritdoc />
    /// <summary>
    /// CompetenceLevel controller
    /// </summary>
    [Route("api/v1/competenceLevel")]
    public class CompetenceLevelController : ApiControllerBase
    {
        #region Fields

        private readonly ICompetenceLevelService _competenceLevelService;
        private readonly IMapper _mapper;

        #endregion

        #region Public Functions

        /// <inheritdoc />
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="factory"></param>
        public CompetenceLevelController(IChatBotDataFactory factory)
        {
            _competenceLevelService = factory.GetCompetenceLevelService();
            _mapper = factory.GetMapperService();
        }

        /// <summary>
        /// Get many async
        /// </summary>
        /// <returns></returns>
        [HttpGet(Common.Constants.GetMany)]
        public async Task<ActionResult> GetManyAsync([FromQuery] int? id, [FromQuery]string name, [FromQuery] string createdyBy)
        {
            return await GetResponseAsync(async () => (await _competenceLevelService.GetCompetenceLevelsAsync(id, name, createdyBy))
                .GetMappedResponse<IEnumerable<CompetenceLevel>, IEnumerable<CompetenceLevelResponse>>(_mapper));
        }
         
        #endregion
    }
}
