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
        //protected readonly IHostingEnvironment Environment;
        //protected readonly ILogger<ApiControllerBase> LoggingService;

        //protected ApiControllerBase(IHostingEnvironment environment, ILogger<ApiControllerBase> loggingService)
        //{
        //    Environment = environment;
        //    LoggingService = loggingService;
        //}

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
                //  LoggingService.LogError("The request could not be processed", ex);
            }
            catch (SecurityException)
            {
                result = Forbid();
                // LoggingService.LogError("SecurityException occurred", ex);
            }
            catch
            {
                result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
                // LoggingService.LogError("Unknown Exception occurred", ex);
            }
            return result;
        }

        /// <summary>
        /// Get response async 
        /// </summary>
        /// <param name="codeToExecute"></param>
        /// <param name="successStatusCode"></param>
        /// <returns></returns>
        protected async Task<ActionResult> GetResponseAsync(Func<Task> codeToExecute,
            HttpStatusCode successStatusCode = HttpStatusCode.OK)
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
                // LoggingService.LogError("The request could not be processed", ex);
            }
            catch (SecurityException)
            {
                result = Forbid();
                // LoggingService.LogError("SecurityException occurred", ex);
            }
            catch
            {
                result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
                // LoggingService.LogError("Unknown Exception occurred", ex);
            }
            return result;
        }
    }
}