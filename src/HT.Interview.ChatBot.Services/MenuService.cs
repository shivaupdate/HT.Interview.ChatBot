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
    /// Role Service
    /// </summary>
    public class MenuService : IMenuService
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
        public MenuService(IChatBotDataFactory factory, IChatBotDataContext chatbotDataContext)
        {
            _chatbotDataContext = chatbotDataContext;
            _resourceService = factory.GetResourceService(Common.Constants.ResourceComponent);
        }

        #region Get Menus

        /// <summary>
        /// Get Menus async
        /// </summary>
        /// <param name="id"></param>
        /// <param name="options"></param>
        /// <param name="createdBy"></param>
        /// <returns></returns>
        public async Task<Response<IEnumerable<Menu>>> GetMenusAsync(int? id, string options, string createdBy)
        {
            IEnumerable<Menu> Menus = await _chatbotDataContext.Menu.ToListAsync();
            // TODO: Search Menu result list against search parameters
            return Response.Ok(Menus);
        }

        #endregion

        #endregion
    }
}