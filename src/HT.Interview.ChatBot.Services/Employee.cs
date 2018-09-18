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
    /// Employee Service
    /// </summary>
    public class EmployeeService : IEmployeeService
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
        public EmployeeService(IChatBotDataFactory factory, IChatBotDataContext chatbotDataContext)
        {
            _chatbotDataContext = chatbotDataContext;
            _resourceService = factory.GetResourceService(Common.Constants.ResourceComponent);
        }

        public async Task<Response> AddEmployeeAsync(Employee employee)
        {
            try
            {
                _chatbotDataContext.Employee.Add(employee);
                await _chatbotDataContext.SaveChangesAsync();
                return Response.Ok();
            }
            catch (System.Exception ex)
            {
                ex.Message.ToString();
                return null;
            }
        }

        public async Task<Response> DeleteEmployeeAsync(Employee employee)
        {
            try
            {
                _chatbotDataContext.Employee.Remove(employee);
                await _chatbotDataContext.SaveChangesAsync();
                return Response.Ok();
            }
            catch (System.Exception ex)
            {
                ex.Message.ToString();
                return null;
            }
        }

        #region Get Employees

        /// <summary>
        /// Get Employees async
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="createdBy"></param>
        /// <returns></returns>
        public async Task<Response<IEnumerable<Employee>>> GetEmployeesAsync(Employee obj)
        {
            IEnumerable<Employee> Employees = await _chatbotDataContext.Employee.ToListAsync();
            // TODO: Search Employees result list against search parameters
            return Response.Ok(Employees);
        }

        public async Task<Response> UpdateEmployeeAsync(Employee employee)
        {
            try
            {
                _chatbotDataContext.Employee.Update(employee);
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