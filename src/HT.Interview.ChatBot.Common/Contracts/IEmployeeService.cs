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

        /// <summary>
        /// Add Employee async
        /// </summary>
        /// <param name="Employee class"></param>      
        /// <returns></returns>
        Task<Response> AddEmployeeAsync(Employee employee);

        /// <summary>
        /// Update Employee async
        /// </summary>
        /// <param name="Employee class"></param>      
        /// <returns></returns>
        Task<Response> UpdateEmployeeAsync(Employee employee);

        /// <summary>
        /// Delete Employee async
        /// </summary>
        /// <param name="Employee class"></param>      
        /// <returns></returns>
        Task<Response> DeleteEmployeeAsync(Employee employee);
    }
}
