﻿using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;

namespace PayloadPost.Filters
{
    public class AddXTokenSwaggerOperationFilter : IOperationFilter
    {
        public void Apply(Operation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
                operation.Parameters = new List<IParameter>();


            operation.Parameters.Add(new NonBodyParameter
            {
                Name = "x-token",
                In = "header",
                Type = "string",
                Required = false,
                Default = "Bearer "
            });
        }
    }
}
