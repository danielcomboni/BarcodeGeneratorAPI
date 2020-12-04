using Microsoft.Extensions.Configuration;

namespace BarcodeGeneratorAPI.Core.Helpers
{
    public static class OpenApiHelper
    {
        public static OpenApiInfo OpenApiConfig(this IConfiguration configuration)
        {
            var openApiInfo = new OpenApiInfo();
            configuration.GetSection("OpenApiInfo").Bind(openApiInfo);
            return openApiInfo;
        }
        public class OpenApiInfo
        {
            public string Version { get; set; }
            public string Title { get; set; }
            public License License { get; set; }
            public string Description { get; set; }

            public Contact Contact { get; set; }
        }

        public class License
        {
            public string Name { get; set; }
            public string Url { get; set; }

        }

        public class Contact
        {
            public string Name { get; set; }
            public string Email { get; set; }

        }
    }
}
