using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SurveyConsole.Models
{
    public class AppsSettings
    {
        [JsonPropertyName("Logging")]
        public Logging Logging { get; set; }

        [JsonPropertyName("ConnectionStrings")]
        public ConnectionStrings ConnectionStrings { get; set; }

        [JsonPropertyName("AllowedHosts")]
        public string AllowedHosts { get; set; }

        [JsonPropertyName("CustomConfig")]
        public CustomConfig CustomConfig { get; set; }

        [JsonPropertyName("Encryption")]
        public Encryption Encryption { get; set; }

        [JsonPropertyName("JWTEncryption")]
        public JWTEncryption JWTEncryption { get; set; }

        public String SIAPUrl { get; set; }
    }

    // Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
    public class LogLevel
    {
        [JsonPropertyName("Default")]
        public string Default { get; set; }

        [JsonPropertyName("Microsoft")]
        public string Microsoft { get; set; }

        [JsonPropertyName("Microsoft.Hosting.Lifetime")]
        public string MicrosoftHostingLifetime { get; set; }
    }

    public class Logging
    {
        [JsonPropertyName("LogLevel")]
        public LogLevel LogLevel { get; set; }
    }

    public class ConnectionStrings
    {
        [JsonPropertyName("SurvDB")]
        public string SurvDB { get; set; }
    }

    public class CustomConfig
    {
        [JsonPropertyName("GoogleCredential")]
        public string GoogleCredential { get; set; }
        public string DefaultFCMDestinationToken { get; set; }
    }

    public class Encryption
    {
        public string iv { get; set; }
        public string key { get; set; }
    }

    public class JWTEncryption
    {
        public string iv { get; set; }
        public string key { get; set; }
    }

}
