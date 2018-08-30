using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Controllers;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Linq;
using System.Reflection;

namespace HT.Framework.MVC
{
    public class SwaggerIgnoreDocFilter : IDocumentFilter
    {
        public void Apply(SwaggerDocument swaggerDoc, DocumentFilterContext context)
        {
            for (int i = 0; i < context.ApiDescriptionsGroups.Items.Count; i++)
            {
                ApiDescriptionGroup group = context.ApiDescriptionsGroups.Items[i];
                foreach (ApiDescription apiDescription in group.Items)
                {
                    if (!(apiDescription.ActionDescriptor is ControllerActionDescriptor actionDescriptor))
                    {
                        return;
                    }
                    //Remove the API from the swagger definition if marked as SwaggerIgnore
                    if (CustomAttributeExtensions.GetCustomAttributes<SwagggerIgnoreAttribute>(actionDescriptor.ControllerTypeInfo).Any()
                        || CustomAttributeExtensions.GetCustomAttributes<SwagggerIgnoreAttribute>(actionDescriptor.MethodInfo).Any())
                    {
                        string route = "/" + apiDescription.RelativePath.TrimEnd('/');
                        swaggerDoc.Paths.Remove(route);
                    }
                }

            }
        }
    }
}
