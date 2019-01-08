namespace OrdersService.WebApi.Models
{
    public sealed class Issue
    {
        public FieldsCollection Fields { get; set; }
        public string Id { get; set; }

        public sealed class FieldsCollection
        {
            public string Summary { get; set; }
        }
    }
}
