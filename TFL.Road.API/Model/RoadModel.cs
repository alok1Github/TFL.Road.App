﻿using System.Text.Json.Serialization;

namespace TFL.API.Model
{
    public class RoadModel : IModel
    {
        public List<RoadResult> RoadDetails { get; set; }
    }
    public class RoadResult
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
}