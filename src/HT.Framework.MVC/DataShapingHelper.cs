using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;

namespace HT.Framework.MVC
{
    /// <summary>
    /// DataShapingHelper
    /// </summary>
    public class DataShapingHelper
    {
        /// <summary>
        /// Pagindation default fields
        /// </summary>
        public string PaginataionDefaultFields => "CurrentPage,TotalPages,TotalCount,PageSize,HasPreviousPage,HasNextPage";

        /// <summary>
        /// Create shaped data <typeparamref name="T"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="fields"></param>
        /// <param name="seperator"></param>
        /// <returns></returns>
        public IQueryable<object> CreateShapedData<T>(IQueryable<T> obj, string fields = "", char seperator = ',')
        {
            return CreateShapedData(obj.AsEnumerable(), fields, seperator).AsQueryable();
        }

        /// <summary>
        /// Create shaped data <typeparamref name="T"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="fields"></param>
        /// <param name="seperator"></param>
        /// <returns></returns>
        public IEnumerable<object> CreateShapedData<T>(IEnumerable<T> obj, string fields = "", char seperator = ',')
        {
            IEnumerable<string> listOfFields = null;
            if (fields != null)
            {
                listOfFields = fields.Split(seperator);
            }
            return obj.Select(x => { return CreateShapedData(x, listOfFields); });
        }

        /// <summary>
        /// Create shaped data <typeparamref name="T"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="fields"></param>
        /// <param name="seperator"></param>
        /// <returns></returns>
        public object CreateShapedData<T>(T obj, string fields = "", char seperator = ',')
        {
            IEnumerable<string> listOfFields = null;
            if (fields != null)
            {
                listOfFields = fields.Split(seperator);
            }
            return CreateShapedData(obj, listOfFields);
        }

        /// <summary>
        /// Create shaped data <typeparamref name="T"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="listOfFields"></param>
        /// <returns></returns>
        public object CreateShapedData<T>(T obj, IEnumerable<string> listOfFields)
        {
            if (listOfFields == null || !listOfFields.Any())
            {
                return obj;
            }
            ExpandoObject objectToReturn = new ExpandoObject();
            foreach (var field in listOfFields)
            {
                // need to include public and instance, b/c specifying a binding flag overwrites the
                // already-existing binding flags.
                var trimmedField = field.Trim();
                var fieldValue = obj.GetType()
                    .GetProperty(trimmedField, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance)
                    .GetValue(obj, null);

                // add the field to the ExpandoObject
                ((IDictionary<String, Object>)objectToReturn).Add(trimmedField, fieldValue);
            }
            return objectToReturn;
        }

        /// <summary>
        /// Create pageable shaped data <typeparamref name="T"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="fields"></param>
        /// <param name="seperator"></param>
        /// <returns></returns>
        public object CreatePageableShapedData<T>(Pageable<T> obj, string fields = "", char seperator = ',')
        {
            IEnumerable<string> listOfFields = null;
            if (fields != null)
            {
                listOfFields = fields.Split(seperator);
            }
            ExpandoObject objectToReturn = new ExpandoObject();
            var defaultPagingProps = (IDictionary<String, Object>)CreateShapedData(obj, PaginataionDefaultFields.Split(seperator));
            foreach (var property in defaultPagingProps)
            {
                ((IDictionary<String, Object>)objectToReturn).Add(property.Key, property.Value);
            }
            object itemProperty = obj.Items.Select(x => { return CreateShapedData(x, listOfFields); });
            ((IDictionary<String, Object>)objectToReturn).Add("Items", itemProperty);
            return objectToReturn;
        }
    }
}