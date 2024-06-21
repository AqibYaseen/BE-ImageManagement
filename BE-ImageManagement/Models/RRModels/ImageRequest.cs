namespace BE_ImageManagement.Models.RRModels;

public class ImageRequest
{
    public string User { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string URL { get; set; } = string.Empty;
}


public class ImageUpdateRequest
{
    public int Id { get; set; }
    public string User { get; set; } = string.Empty;
    public DateTime DateCreated { get; set; }
    public string Description { get; set; } = string.Empty;
    public string URL { get; set; } = string.Empty;
}
