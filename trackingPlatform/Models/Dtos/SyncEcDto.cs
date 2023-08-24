namespace trackingPlatform.Models.Dtos
{
    public class SyncEcDto
    {
        public SyncEcDto(PostDto cnnDbResult, PostDto ecDbResult)
        {
            this.cnnDbResult = cnnDbResult;
            this.ecDbResult = ecDbResult;
        }

        public PostDto cnnDbResult { get; set; }

        public PostDto ecDbResult { get; set; }
    }
}
