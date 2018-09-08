using HT.Framework; 
using HT.Interview.ChatBot.Common.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HT.Interview.ChatBot.Common.Contracts
{
    /// <summary>
    /// IEmployeeService
    /// </summary>
    public interface IEmployeeService
    {
        /// <summary>
        /// Get Employees async
        /// </summary>
        /// <param name="employee class"></param>
      
        /// <returns></returns>
        Task<Response<IEnumerable<Employee>>> GetEmployeesAsync(Employee employee);
    }
}
