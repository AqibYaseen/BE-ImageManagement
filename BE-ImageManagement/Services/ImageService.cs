using BE_ImageManagement.Interfaces;
using BE_ImageManagement.Models;
using BE_ImageManagement.Models.Entities;
using BE_ImageManagement.Models.RRModels;

namespace BE_ImageManagement.Services
{
    public class ImageService : IImageService
    {
        public Task<ApiResponse<ImageResponse?>> GetImage(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<IEnumerable<ImageResponse>>> GetImages()
        {
            throw new NotImplementedException();
        }



        //this method is used to get the data from the file that we are using to store the data locally.
        private IEnumerable<Image> ReadJsonFromFile()
        {
            List<Image> images = new List<Image>();
            try
            {
                string jsonData = File.ReadAllText(_filePath);
                images = JsonConvert.DeserializeObject<List<Image>>(jsonData);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error reading JSON file: {ex.Message}");
            }

            return images;
        }
    }
}
}
