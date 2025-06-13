using A_journey_through_miniature_Uzhhorod.Database;
using A_journey_through_miniature_Uzhhorod.Properties;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.IO;

namespace A_journey_through_miniature_Uzhhorod.MVVM.ViewModel
{
    public class MapeViewModel : ViewModelBase
    {
        private readonly IAppDbContextFactory _contextFactory;
        public event Action OnMarkersReloadRequested;

        public MapeViewModel(IAppDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;

            LanguageManager.LanguageChanged += () =>
            {
                LoadMarkers();
            };
        }

        public void LoadMarkers()
        {
            using var context = _contextFactory.CreateContext();

            string currentLanguage = Settings.Default.LanguageCode ?? "uk";

            var miniatures = context.Miniatures
                .Include(m => m.Translations)
                .AsNoTracking()
                .ToList()
                .Select(m => new
                {
                    Latitude = m.Latitude.ToString(CultureInfo.InvariantCulture),
                    Longitude = m.Longitude.ToString(CultureInfo.InvariantCulture),
                    Name = m.Translations.FirstOrDefault(t => t.LanguageCode == currentLanguage)?.Name ?? "Невідома мініатюра",
                    ImageUrl = GetBlobImageUrl(m.ImageUrl)
                })
                .ToList();

            List<string> markers = new();

            foreach (var miniature in miniatures)
            {
                string markerData = $"addMarker({miniature.Latitude}, {miniature.Longitude}, \"{miniature.Name}\", \"{miniature.ImageUrl}\");";
                markers.Add(markerData);
            }

            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "MVVM/Model/Map/markers.js");
            File.WriteAllLines(filePath, markers);
        }

        private string GetBlobImageUrl(string? imageUrl)
        {
            const string fallbackImage = "notFound.png";
            const string blobBaseUrl = "https://minisculptures.blob.core.windows.net/images/";

            if (string.IsNullOrWhiteSpace(imageUrl))
                return blobBaseUrl + fallbackImage;

            if (Uri.TryCreate(imageUrl, UriKind.Absolute, out var uri) && uri.Scheme.StartsWith("http"))
                return imageUrl;

            string fileName = Path.GetFileName(imageUrl.Replace("\\", "/"));
            return blobBaseUrl + fileName;
        }
    }
}
