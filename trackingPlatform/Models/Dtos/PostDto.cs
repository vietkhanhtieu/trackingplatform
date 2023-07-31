using Microsoft.AspNetCore.Identity;

namespace trackingPlatform.Models.Dtos
{
    public class PostDto
    {
        public int NumberOfCreate { get; set; } = 0;

        public int NumberOfUpdate { get; set; } = 0;

        public int NumberOfError { get; set; } = 0;

        public List<EntityError> EntityErrors { get; set; } = new List<EntityError>();
    }
}
