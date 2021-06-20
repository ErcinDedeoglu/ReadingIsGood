using System;
using System.Linq;
using System.Reflection;
using Swashbuckle.Swagger;

namespace ReadingIsGood.Business.Attribute
{
    public class SwaggerExcludeFilter : ISchemaFilter
    {
        public void Apply(Schema schema, SchemaRegistry schemaRegistry, Type type)
        {
            if (schema?.properties == null || type == null)
                return;

            var excludedProperties = type.GetProperties()
                .Where(t =>
                    t.GetCustomAttribute<SwaggerExcludeAttribute>()
                    != null);

            foreach (var excludedProperty in excludedProperties)
                if (schema.properties.ContainsKey(excludedProperty.Name))
                    schema.properties.Remove(excludedProperty.Name);
        }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class SwaggerExcludeAttribute : System.Attribute
    {
    }
}