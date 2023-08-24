using trackingPlatform.Models.Dtos;

namespace trackingPlatform.Utils
{
    public class PostDtoUtils
    {
        public static PostDto UpdatePostDto(PostDto oldPostDto, PostDto newPostDto) 
        {
            PostDto result = new PostDto();
            result.NumberOfCreate = oldPostDto.NumberOfCreate + newPostDto.NumberOfCreate;
            result.NumberOfError = oldPostDto.NumberOfError + newPostDto.NumberOfError;
            result.NumberOfUpdate = oldPostDto.NumberOfUpdate + newPostDto.NumberOfUpdate;
            result.EntityErrors = oldPostDto.EntityErrors.Union(newPostDto.EntityErrors).ToList();
            return result;
        }
    }
}
