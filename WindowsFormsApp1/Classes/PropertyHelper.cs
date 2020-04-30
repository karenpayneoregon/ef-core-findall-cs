using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Classes
{
    /// <summary>
    /// http://www.developer-corner.com/blog/2007/07/19/datagridview-how-to-bind-nested-objects/
    /// https://github.com/jeden/DataGridViewSample
    /// </summary>
    public class PropertyHelper
    {
        public static string BindModelProperty(object property, string propertyName)
        {
            var result = "";

            if (propertyName.Contains("."))
            {
                var leftPropertyName = propertyName.Substring(0, 
                    propertyName.IndexOf(".", StringComparison.Ordinal));

                var properties = property.GetType().GetProperties();

                foreach (var propertyInfo in properties)
                {

                    if (propertyInfo.Name != leftPropertyName) continue;

                    result = BindModelProperty(propertyInfo.GetValue(property, null), 
                        propertyName.Substring(propertyName.IndexOf(".", StringComparison.Ordinal) + 1));

                    break;
                }
            }
            else
            {
                var propertyType = property.GetType();
                var propertyInfo = propertyType.GetProperty(propertyName);

                if (propertyInfo != null)
                {
                    result = propertyInfo.GetValue(property, null).ToString();
                }
            }

            return result;
        }

    }
}
