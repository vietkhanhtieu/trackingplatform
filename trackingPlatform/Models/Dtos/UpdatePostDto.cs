namespace trackingPlatform.Models.Dtos
{
    public class UpdatePostDto
    {
        public static PostDto UpdatePostDto1(PostDto post1, PostDto post2)
        {
            PostDto result = new PostDto();
            result.NumberOfUpdate = post1.NumberOfUpdate + post2.NumberOfUpdate;
            result.NumberOfError = post1.NumberOfError + post2.NumberOfError;
            result.NumberOfCreate = post1.NumberOfCreate + post2.NumberOfCreate;
            result.EntityErrors = post1.EntityErrors.Concat(post2.EntityErrors).ToList();
            return result;
        }
    }
}
