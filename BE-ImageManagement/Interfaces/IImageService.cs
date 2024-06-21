using BE_ImageManagement.Models;
using BE_ImageManagement.Models.RRModels;

namespace BE_ImageManagement.Interfaces;

public interface IImageService
{

    ApiResponse<List<ImageResponse>> GetImages();
    ApiResponse<ImageResponse> GetImage(int id);
    ApiResponse<ImageResponse> AddImage(ImageRequest model);
    ApiResponse<ImageResponse> UpdateImage(ImageUpdateRequest model);
    ApiResponse<ImageResponse> DeleteImage(int id);
}
