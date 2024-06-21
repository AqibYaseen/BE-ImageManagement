using BE_ImageManagement.Models;
using BE_ImageManagement.Models.RRModels;

namespace BE_ImageManagement.Interfaces;

public interface IImageService
{

    Task<ApiResponse<IEnumerable<ImageResponse>>> GetImages();
    Task<ApiResponse<ImageResponse?>> GetImage(int id);
}
