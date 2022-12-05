namespace DemoJWT_MySQL.DTO.Image
{
    public class ImageDTO
    {
        public string Url { get; set; }

        public ImageDTO(string url)
        {
            Url = url;
        }
    }
}
