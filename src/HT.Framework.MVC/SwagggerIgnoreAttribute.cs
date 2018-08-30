using System;

namespace HT.Framework.MVC
{
    //This is marker attribute that identifies the controllers/actions
    //that need to be hidden from the Swagger.json 
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class SwagggerIgnoreAttribute : Attribute
    {
    }
}