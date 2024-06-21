namespace BE_ImageManagement.Models.Entities;

public class Image
{
    public int Id { get; set; }
    public string User { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string URL { get; set; } = string.Empty;
    public DateTime DateCreated { get; set; }
}