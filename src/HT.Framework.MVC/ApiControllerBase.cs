using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Security;
using System.Threading.Tasks;

namespace HT.Framework.MVC
{
    /// <summary>
    /// ApiControllerBase
    /// </summary>
    public abstract class ApiControllerBase : Controller
    {

        /// <summary>
        /// Get Api Ai response async <typeparamref name="T"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="codeToExecute"></param>
        /// <returns></returns>
        [EnableCors("InterviewChatBot")]
        protected async Task<ActionResult> GetApiAiResponseAsync<T>(Func<Task<T>> codeToExecute)
        {
            ActionResult result;
            try
            {
                T r = await codeToExecute().ConfigureAwait(false);
                result = r == null ? (ActionResult)NotFound() : Ok(r);
            }
            catch (InvalidOperationException ex)
            {
                result = BadRequest(ex.Message);
            }
            catch (SecurityException)
            {
                result = Forbid();
            }
            catch
            {
                result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
            return result;
        }


        /// <summary>
        /// Get response async <typeparamref name="T"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="codeToExecute"></param>
        /// <returns></returns>
        protected async Task<ActionResult> GetResponseAsync<T>(Func<Task<T>> codeToExecute)
        {
            ActionResult result;
            try
            {
                T r = await codeToExecute().ConfigureAwait(false);
                result = r == null ? (ActionResult)NotFound() : Ok(r);
            }
            catch (InvalidOperationException ex)
            {
                result = BadRequest(ex.Message);
            }
            catch (SecurityException)
            {
                result = Forbid();
            }
            catch
            {
                result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
            return result;
        }

        /// <summary>
        /// Get response async 
        /// </summary>
        /// <param name="codeToExecute"></param>
        /// <param name="successStatusCode"></param>
        /// <returns></returns>
        protected async Task<ActionResult> GetResponseAsync(Func<Task> codeToExecute, HttpStatusCode successStatusCode = HttpStatusCode.OK)
        {
            ActionResult result;
            try
            {
                await codeToExecute().ConfigureAwait(false);
                result = StatusCode((int)successStatusCode);
            }
            catch (InvalidOperationException ex)
            {
                result = BadRequest(ex.Message);
            }
            catch (SecurityException)
            {
                result = Forbid();
            }
            catch
            {
                result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
            return result;
        }
    }
}