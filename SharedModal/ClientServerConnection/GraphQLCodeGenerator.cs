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
        public static string Parameter_Object_Return_Object<Parameter, Response>(string queryName, string parameterTypeName, Parameter variables, Response returnObject)
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
   
    }
}
