using HT.Framework; 
using HT.Interview.ChatBot.Common.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HT.Interview.ChatBot.Common.Contracts
{
    /// <summary>
    /// IMenuService
    /// </summary>
    public interface IMenuService
    {
        /// <summary>
        /// Get menus async
        /// </summary>
        /// <param name="id"></param>
        /// <param name="options"></param>
        /// <param name="createdBy"></param>
        /// <returns></returns>
        Task<Response<IEnumerable<Menu>>> GetMenusAsync(int? id, string options, string createdBy);
    }
}
