using System.Text.Json;
using System.Xml;
using BE_ImageManagement.Interfaces;
using BE_ImageManagement.Models;
using BE_ImageManagement.Models.Entities;
using BE_ImageManagement.Models.RRModels;
using BE_ImageManagement.Utils;

namespace BE_ImageManagement.Services
{
    public class ImageService(ImageUtils utils) : IImageService
    {
        public ApiResponse<ImageResponse> AddImage(ImageRequest model)
        {
            var image = new Image()
            {
                DateCreated = DateTime.Now,
                Description = model.Description,
                URL = model.URL,
                User = model.User
            };

            try
            {
                var savedImage = utils.SaveImageToJsonFile(image);
                return ApiResponse<ImageResponse>.Success(
                    new ImageResponse { DateCreated = image.DateCreated, Id = savedImage.Id, Description = image.Description, URL = image.URL, User = image.User },
                    "Image saved successfully", System.Net.HttpStatusCode.Created);
            }
            catch(Exception)
            {
                return ApiResponse<ImageResponse>.Error("Error while saving the image", System.Net.HttpStatusCode.InternalServerError);
            }
        }

        public ApiResponse<ImageResponse> DeleteImage(int id)
        {
            var result = utils.DeleteImageFromJsonFile(id);

            if(result is null)
            {
                return ApiResponse<ImageResponse>.Error("Could not delete image", System.Net.HttpStatusCode.InternalServerError);
            }
            var response = new ImageResponse
            {
                DateCreated = result.DateCreated,
                Description = result.Description,
                Id = id,
                URL = result.URL,
                User = result.User
            };
            return ApiResponse<ImageResponse>.Success(response, "Image deleted successfully", System.Net.HttpStatusCode.InternalServerError);
        }


        public ApiResponse<ImageResponse> GetImage(int id)
        {
            List<Image>? images = utils.ReadJsonFromFile();

            if(images is null || images.Count == 0)
                return ApiResponse<ImageResponse>.Error("No Images Found", System.Net.HttpStatusCode.NoContent);


            var image = images.FirstOrDefault(i => i.Id == id);

            if(image is null)
                return ApiResponse<ImageResponse>.Error($"No Images Found with id {id}", System.Net.HttpStatusCode.NoContent);


            return ApiResponse<ImageResponse>.Success(new()
            {
                Id = image.Id,
                Description = image.Description,
                URL = image.URL,
                User = image.User,
                DateCreated = image.DateCreated,
            }, "Successful");


        }
        public ApiResponse<List<ImageResponse>> GetImages()
        {
            List<Image>? images = utils.ReadJsonFromFile();

            if(images is null || images.Count == 0)
                return ApiResponse<List<ImageResponse>>.Success([], "No Images Found", System.Net.HttpStatusCode.NoContent);

            var imageResponse = images.Select(image => new ImageResponse
            {
                DateCreated = image.DateCreated,
                Description = image.Description,
                Id = image.Id,
                URL = image.URL,
                User = image.User
            }).ToList();

            var response = ApiResponse<List<ImageResponse>>.Success(imageResponse, "Successful");

            return response;
        }

        public ApiResponse<ImageResponse> UpdateImage(ImageUpdateRequest model)
         {
            var image = new Image
            {
                Id = model.Id,
                URL = model.URL,
                User = model.User,
                DateCreated = model.DateCreated,
                Description = model.Description,
            };


            try
            {
                var updatedImage = utils.UpdateImageToJsonFile(image);

                if(updatedImage is null) return ApiResponse<ImageResponse>.Error("Error updating image", System.Net.HttpStatusCode.InternalServerError);


                var response = new ImageResponse
                {
                    Id = model.Id,
                    URL = model.URL,
                    User = model.User,
                    Description = updatedImage.Description,
                    DateCreated = updatedImage.DateCreated,
                };

                return ApiResponse<ImageResponse>.Success(response, "Image updated successfully");

            }
            catch(Exception)
            {
                return ApiResponse<ImageResponse>.Error("Error updating image", System.Net.HttpStatusCode.InternalServerError);
            }
        }
    }
}
