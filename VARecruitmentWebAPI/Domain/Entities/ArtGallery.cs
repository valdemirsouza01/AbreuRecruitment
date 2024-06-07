﻿namespace VAArtGalleryWebAPI.Domain.Entities
{
    public class ArtGallery(string name, string city, string manager, Guid id = default)
    {
        public Guid Id { get; set; } = id == Guid.Empty ? Guid.NewGuid() : id;

        public string Name { get; set; } = string.IsNullOrEmpty(name) ? throw new ArgumentException("Invalid name", nameof(name)) : name;

        public string City { get; set; } = string.IsNullOrEmpty(city) ? throw new ArgumentException("Invalid address", nameof(city)) : city;

        public string Manager { get; set; } = string.IsNullOrEmpty(manager) ? throw new ArgumentException("Invalid manager name", nameof(manager)) : manager;

        public List<ArtWork>? ArtWorksOnDisplay { get; set; }

        public IEnumerable<ArtWork> DisplayNewArtWork(ArtWork artwork)
        {
            ArgumentNullException.ThrowIfNull(artwork);

            if (ArtWorksOnDisplay == null)
            {
                ArtWorksOnDisplay = new List<ArtWork>(new[] { artwork });
            }
            else
            {
                ArtWorksOnDisplay.Add(artwork);
            }

            return ArtWorksOnDisplay;
        }

        public IEnumerable<ArtWork>? SellArtWork(ArtWork artwork)
        {
            ArgumentNullException.ThrowIfNull(artwork);

            if (ArtWorksOnDisplay == null || ArtWorksOnDisplay.Count == 0 || !IsArtWorkOnDisplay(artwork.Id))
            {
                return null;
            }

            ArtWorksOnDisplay.Remove(ArtWorksOnDisplay.First(aw => aw.Id == artwork.Id));

            return ArtWorksOnDisplay;
        }

        private bool IsArtWorkOnDisplay(Guid id) => ArtWorksOnDisplay?.Select(aw => aw.Id).Contains(id) ?? false;
    }
}