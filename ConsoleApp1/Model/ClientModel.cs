namespace TFL.ClientApp.Model
{
    public class ClientModel
    {
        public List<ClientResult> RoadDetails { get; set; }
    }
    public class ClientResult
    {
        public string Id { get; set; }
        public string DisplayName { get; set; }
        public string StatusSeverity { get; set; }
        public string StatusSeverityDescription { get; set; }
    }
}
