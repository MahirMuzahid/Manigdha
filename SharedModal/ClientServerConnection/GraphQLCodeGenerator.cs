using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SharedModal.ClientServerConnection
{
    public class GraphQLCodeGenerator<Parameter, Response>
    {
        public static string Parameter_Multiple_Return_Object(string queryName, string parameterTypeName, Parameter variables)
        {
            var sb = new StringBuilder();
            sb.Append($"mutation {{ {queryName}({parameterTypeName}: {{ ");

            foreach (var prop in typeof(Parameter).GetProperties())
            {
                var name = char.ToLower(prop.Name[0]) + prop.Name.Substring(1);
                var value = prop.GetValue(variables);
                sb.Append($"{name}: ");
                if (value is string)
                {
                    sb.Append($"\"{value}\"");
                }
                else
                {
                    sb.Append(value.ToString());
                }
                sb.Append(", ");
            }
            sb.Append("}) { ");

            foreach (var prop in typeof(Response).GetProperties())
            {
                sb.Append($"{prop.Name}, ");
            }
            sb.Remove(sb.Length - 2, 2);
            sb.Append(" } }");

            return sb.ToString();
        }
        public static string Parameter_Single_Return_Object(string queryName, string parameterName, Parameter parameterValue, Response returnObject)
        {
            var queryBuilder = new StringBuilder();

            // Append mutation name
            queryBuilder.Append($"mutation {{ {queryName}(");

            // Append parameter name and value
            queryBuilder.Append($"{parameterName}: {parameterValue},");

            // Close parameter object and append return object fields
            queryBuilder.Append(") {");

            var properties = returnObject.GetType().GetProperties();
            foreach (var property in properties)
            {
                var name = Char.ToLower(property.Name[0]) + property.Name.Substring(1);
                queryBuilder.Append($" {name},");
            }

            // Remove trailing comma and close return object
            queryBuilder.Remove(queryBuilder.Length - 1, 1);
            queryBuilder.Append(" } }");

            return queryBuilder.ToString();
        }




    }
}
