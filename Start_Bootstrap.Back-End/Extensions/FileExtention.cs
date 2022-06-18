using Microsoft.AspNetCore.Http;

namespace Start_Bootstrap.Back_End.Extensions
{
    public static class FileExtention
    {
        public static bool IsOkay(this IFormFile file, int mb)
        {
            return file.ContentType.Contains("image") && file.Length > 1024 * 1024 * mb;
        }
    }
}
