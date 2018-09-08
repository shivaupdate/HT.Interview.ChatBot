using HT.Framework; 
using HT.Interview.ChatBot.Common.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HT.Interview.ChatBot.Common.Contracts
{
    /// <summary>
    /// IAttachmentService
    /// </summary>
    public interface IAttachmentService
    {
        /// <summary>
        /// Get Attachment async
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="createdBy"></param>
        /// <returns></returns>
        Task<Response<IEnumerable<Attachment>>> GetAttachmentsAsync(Attachment attachment);
    }
}
