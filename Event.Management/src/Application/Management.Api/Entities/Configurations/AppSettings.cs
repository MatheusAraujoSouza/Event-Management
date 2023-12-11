namespace Management.Api.Entities.Configurations
{
    [AttributeUsage(AttributeTargets.Property)]
    public class AppSettings : Attribute
    {
        public const string SectionName = "AppSettings";

        [ConfigurationKeyName("AllowedHosts")]
        public string AllowedHosts { get; set; }

        [ConfigurationKeyName("Server")]

        public ServerSettings Server { get; set; }

        [ConfigurationKeyName("Swagger")]

        public SwaggerSettings Swagger { get; set; }

        [ConfigurationKeyName("EventManagement")]

        public EventManagementSettings EventManagement { get; set; }
    }

    public class ServerSettings
    {
        [ConfigurationKeyName("Port")]
        public int Port { get; set; }
    }

    public class SwaggerSettings
    {
        [ConfigurationKeyName("Enable")]
        public bool Enable { get; set; }

        [ConfigurationKeyName("UIEndpoint")]
        public string UIEndpoint { get; set; }

        [ConfigurationKeyName("JsonEndpoint")]
        public string JsonEndpoint { get; set; }
    }

    public class EventManagementSettings
    {
        [ConfigurationKeyName("ApiName")]
        public string ApiName { get; set; }
        [ConfigurationKeyName("Version")]
        public string Version { get; set; }
        [ConfigurationKeyName("Description")]
        public string Description { get; set; }
    }

}
