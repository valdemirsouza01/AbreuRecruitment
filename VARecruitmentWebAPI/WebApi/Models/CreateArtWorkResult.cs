using System.Xml.Linq;

namespace VAArtGalleryWebAPI.WebApi.Models
{
    public class CreateArtWorkResult(Guid artWorkId, string name, string author, int creationYear, decimal askPrice)
    {
        public Guid artWorkId { get; set; } = artWorkId;
        public string Name { get; set; } = name;
        public string Author { get; set; } = author;
        public int CreationYear { get; set; } = creationYear;
        public decimal AskPrice { get; set; } = askPrice;
    }
}
