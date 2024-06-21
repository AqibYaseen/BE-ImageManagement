using System.Text.Json;
using BE_ImageManagement.Models.Entities;

namespace BE_ImageManagement.Utils;

public class ImageUtils(string webrootpath)
{
    public Image SaveImageToJsonFile(Image newImage)
    {
        try
        {
            List<Image>? images = ReadJsonFromFile();
            if(images is null || !images.Any())
            {
                images = new List<Image>();
                newImage.Id = 1;
            }
            else
                newImage.Id = images!.Max(i => i.Id) + 1;

            images.Add(newImage);

            string jsonData = JsonSerializer.Serialize(images);
            File.WriteAllText(@$"{webrootpath}/Data/MockDB.json", jsonData);

            return newImage;
        }
        catch(Exception ex)
        {
            throw new Exception("Error while saving new image to the db");
        }
    }

    // we cannot update the item directly because it is just an json object in a file
    // so we are getting the index of the item and updating that and saving back into the array.
    public Image? UpdateImageToJsonFile(Image newImage)
    {
        try
        {
            List<Image>? images = ReadJsonFromFile();
            if(images is null || !images.Any())
            {
                return null;
            }
            var oldImageIndex = images.FindIndex(x => x.Id == newImage.Id);

            if(oldImageIndex == -1 ) return null;

            images[oldImageIndex].Description = newImage.Description;
            images[oldImageIndex].User = newImage.User;
            images[oldImageIndex].URL = newImage.URL;


            string jsonData = JsonSerializer.Serialize(images);
            File.WriteAllText(@$"{webrootpath}/Data/MockDB.json", jsonData);

            return newImage;
        }
        catch(Exception ex)
        {
            throw new Exception("Error while saving new image to the db");
        }
    }


    //this method is used to get the data from the file that we are using to store the data locally.
    public List<Image>? ReadJsonFromFile()
    {
        List<Image>? images = new List<Image>();
        try
        {
            string jsonData = File.ReadAllText($@"{webrootpath}/Data/MockDB.json");
            images = JsonSerializer.Deserialize<List<Image>>(jsonData);
        }
        catch(Exception ex)
        {
            throw new Exception("Error Reading JSON file");
        }
        return images;
    }

    public Image? DeleteImageFromJsonFile(int id)
    {
        try
        {
            List<Image>? images = ReadJsonFromFile();
            if(images is null || !images.Any())
            {
                return null;
            }
            var imageToDelete = images.FirstOrDefault(x => x.Id == id);

            if(imageToDelete is null) return null;

            images.Remove(imageToDelete);

            string jsonData = JsonSerializer.Serialize(images);
            File.WriteAllText(@$"{webrootpath}/Data/MockDB.json", jsonData);

            return imageToDelete;
        }
        catch(Exception ex)
        {
            throw new Exception("Error while saving new image to the db");
        }
    }
}
