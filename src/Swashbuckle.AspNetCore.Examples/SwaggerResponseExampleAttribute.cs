using Newtonsoft.Json.Serialization;
using System;
using Newtonsoft.Json;

namespace Swashbuckle.AspNetCore.Examples
{
    /// <inheritdoc />
    /// <summary>
    /// This is used for generating Swagger documentation. Should be used in conjuction with SwaggerResponse - will add examples to SwaggerResponse.
    /// See https://github.com/mattfrear/Swashbuckle.AspNetCore.Examples
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class SwaggerResponseExampleAttribute : Attribute
    {
        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <param name="statusCode">The HTTP status code, e.g. 200</param>
        /// <param name="examplesProviderType">A type that inherits from IExamplesProvider</param>
        /// <param name="contractResolver">If null then the CamelCasePropertyNamesContractResolver will be used. For PascalCase you can pass in typeof(DefaultContractResolver)</param>
        /// <param name="jsonConverter">An optional jsonConverter to use, e.g. typeof(StringEnumConverter) will render strings as enums</param>
        public SwaggerResponseExampleAttribute(int statusCode, Type examplesProviderType, Type contractResolver = null, Type jsonConverter = null)
        {
            StatusCode = statusCode;
            ExamplesProviderType = examplesProviderType;
            JsonConverter = jsonConverter == null ? null : (JsonConverter)Activator.CreateInstance(jsonConverter);
            ContractResolver = (IContractResolver)Activator.CreateInstance(contractResolver ?? typeof(CamelCasePropertyNamesContractResolver));
        }

        public Type ExamplesProviderType { get; }

        public JsonConverter JsonConverter { get; }

        public int StatusCode { get; }

        public IContractResolver ContractResolver { get; private set; }
    }
}
