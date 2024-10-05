using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Notes2Quiz.Web.API.Attributes;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace Notes2Quiz.Web.API.Filters
{
    public class SwaggerParameterFilter : IParameterFilter
    {
        public void Apply(OpenApiParameter parameter, ParameterFilterContext context)
        {
            var parameterAttributes = default(IEnumerable<SwaggerParameterExampleAttribute>);

            if (context.PropertyInfo != null)
            {
                parameterAttributes = context.PropertyInfo.GetCustomAttributes<SwaggerParameterExampleAttribute>();
            }
            else if (context.ParameterInfo != null)
            {
                parameterAttributes = context.ParameterInfo.GetCustomAttributes<SwaggerParameterExampleAttribute>();
            }

            if (parameterAttributes != null && parameterAttributes.Any())
            {
                AddExample(parameter, parameterAttributes);
            }
        }

        private void AddExample(OpenApiParameter parameter, IEnumerable<SwaggerParameterExampleAttribute> parameterAttributes)
        {
            foreach (var item in parameterAttributes)
            {
                var example = new OpenApiExample
                {
                    Value = new OpenApiString(item.Value)
                };

                parameter.Examples.Add(item.Name, example);
            }
        }
    }
}
