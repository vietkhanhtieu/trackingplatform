namespace trackingPlatform.Models.Dtos
{
    public class EntityError
    {
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Message { get; set; } = "No message";
    }
}
