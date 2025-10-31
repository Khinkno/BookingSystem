namespace BookingSystem
{
    using Microsoft.OpenApi.Models;
    using Swashbuckle.AspNetCore.SwaggerGen;
    using System.Linq;

    public class PasswordFormat : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var passwordParameter = operation.Parameters
                .FirstOrDefault(p => p.Name.Equals("password", StringComparison.OrdinalIgnoreCase) && p.In == ParameterLocation.Query);

            if (passwordParameter != null)
            {
                // This forces the Swagger UI to use a password input type
                passwordParameter.Schema.Format = "password";
            }
        }
    }
}
