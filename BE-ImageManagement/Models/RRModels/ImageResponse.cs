namespace BE_ImageManagement.Models.RRModels;

public class ImageResponse
{
    public int Id { get; set; }
    public string User { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string URL { get; set; } = string.Empty;
    public DateTime DateCreated { get; set; }

}
