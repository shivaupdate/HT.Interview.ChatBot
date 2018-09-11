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
    /// Employee controller
    /// </summary>
    [Route("api/v1/employee")]
    public class EmployeeController : ApiControllerBase
    {
        #region Fields

        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;

        #endregion

        #region Public Functions

        /// <inheritdoc />
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="factory"></param>
        public EmployeeController(IChatBotDataFactory factory)
        {
            _employeeService = factory.GetEmployeeService();
            _mapper = factory.GetMapperService();
        }

        /// <summary>
        /// Get many async
        /// </summary>
        /// <returns></returns>
        [HttpGet(Common.Constants.GetMany)]
        public async Task<ActionResult> GetManyAsync([FromQuery] EmployeeRequest employeeRequest)
        {
            return await GetResponseAsync(async () => (await _employeeService.GetEmployeesAsync(_mapper.Map<Employee>(employeeRequest)))
                .GetMappedResponse<IEnumerable<Employee>, IEnumerable<EmployeeResponse>>(_mapper));
        }
         
        #endregion
    }
}
