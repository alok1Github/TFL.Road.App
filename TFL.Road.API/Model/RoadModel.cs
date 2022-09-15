namespace TFL.API.Model
{
    public class RoadModel : IModel
    {
        public List<ValidRoadResult> ValidRoadDetails { get; set; }
        public InvaildValidRoadResult InvalidRoadDetails { get; set; }
    }
    public class ValidRoadResult
    {
        public string Id { get; set; }
        public string DisplayName { get; set; }
        public string StatusSeverity { get; set; }
        public string StatusSeverityDescription { get; set; }
    }

    public class InvaildValidRoadResult
    {
        public string ExceptionType { get; set; }
        public int HttpStatusCode { get; set; }
        public string HttpStatus { get; set; }
        public string Message { get; set; }
    }
}
