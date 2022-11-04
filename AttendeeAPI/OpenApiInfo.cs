using Swashbuckle.AspNetCore.Swagger;

namespace AttendeeAPI
{
    internal class OpenApiInfo : Info
    {
        public string Version { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}