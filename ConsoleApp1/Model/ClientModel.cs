namespace TFL.ClientApp.Model
{
    /*
     *  This model is same is server side but client model should have its own idenity, hence the different model  
     */
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
