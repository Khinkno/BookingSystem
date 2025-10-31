using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Linq;

public class EnumSchemaFilter : ISchemaFilter
{
    public void Apply(OpenApiSchema model, SchemaFilterContext context)
    {
        if (context.Type.IsEnum)
        {
            // Set the type to string so the UI knows to render names
            model.Type = "string";
            model.Format = null;

            // Clear the example and replace with the list of enum names
            model.Example = null;
            model.Enum.Clear();

            // Add all the enum names to the 'enum' property of the schema
            Enum.GetNames(context.Type)
                .ToList()
                .ForEach(name => model.Enum.Add(new OpenApiString(name)));

            // Optional: Add a description
            // model.Description += $"<br>Values: {string.Join(", ", Enum.GetNames(context.Type))}";
        }
    }
}