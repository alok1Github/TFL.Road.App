using System.Text.Json.Serialization;

namespace TFL.API.Model
{
    public class RoadModel : IModel
    {
        public List<ValidRoadResult> RoadDetails { get; set; }
        public InvaildValidRoadResult Errordetails { get; set; }
    }
    public class ValidRoadResult
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("displayName")]
        public string DisplayName { get; set; }

        [JsonPropertyName("statusSeverity")]
        public string StatusSeverity { get; set; }
        [JsonPropertyName("statusSeverityDescription")]
        public string StatusSeverityDescription { get; set; }
    }

    public class InvaildValidRoadResult
    {
        [JsonPropertyName("exceptionType")]
        public string ExceptionType { get; set; }

        [JsonPropertyName("httpStatusCode")]
        public int HttpStatusCode { get; set; }

        [JsonPropertyName("httpStatus")]
        public string HttpStatus { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }
    }
}
