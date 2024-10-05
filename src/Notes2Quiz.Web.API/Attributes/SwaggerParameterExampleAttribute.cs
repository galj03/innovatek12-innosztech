namespace Notes2Quiz.Web.API.Attributes
{
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Property, AllowMultiple = true)]
    public class SwaggerParameterExampleAttribute : Attribute
    {
        public SwaggerParameterExampleAttribute(string name, string value)
        {
            Name = name ?? string.Empty;
            Value = value ?? string.Empty;
        }

        public SwaggerParameterExampleAttribute(string value)
        {
            Name = value ?? string.Empty;
            Value = value ?? string.Empty;
        }

        public string Name { get; set; }
        public string Value { get; set; }
    }
}
