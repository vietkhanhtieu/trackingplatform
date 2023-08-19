using trackingPlatform.Models.Dtos;

namespace trackingPlatform.Utils
{
    public class PostDtoUtils
    {
        public static PostDto UpdatePostDto(PostDto oldpostDto, PostDto newPostDto) 
        {
            PostDto result = new PostDto();
            result.NumberOfCreate = oldpostDto.NumberOfCreate + newPostDto.NumberOfCreate;
            result.NumberOfError = oldpostDto.NumberOfError + newPostDto.NumberOfError;
            result.NumberOfUpdate = oldpostDto.NumberOfUpdate + newPostDto.NumberOfUpdate;
            result.EntityErrors = oldpostDto.EntityErrors.Union(newPostDto.EntityErrors).ToList();
            return result;
        }
    }
}
