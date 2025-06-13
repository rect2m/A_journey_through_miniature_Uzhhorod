using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace A_journey_through_miniature_Uzhhorod.MVVM.Model.Service
{
    public class BlobStorageService
    {
        private readonly BlobServiceClient _blobServiceClient;
        private readonly string _baseUrl;
        public string ImageContainerName { get; }
        public string ModelContainerName { get; }
        public string AvatarContainerName { get; }

        public BlobStorageService(IConfiguration configuration)
        {
            var section = configuration.GetSection("AzureBlobStorage");
            var connectionString = section["ConnectionString"];
            _baseUrl = "https://" + new BlobServiceClient(connectionString).AccountName + ".blob.core.windows.net";

            _blobServiceClient = new BlobServiceClient(connectionString);
            ImageContainerName = section["ImageContainer"] ?? "images";
            ModelContainerName = section["ModelContainer"] ?? "models";
            AvatarContainerName = section["AvatarContainer"] ?? "avatars";
        }

        public async Task UploadFileAsync(Stream stream, string fileName, string containerName)
        {
            var container = _blobServiceClient.GetBlobContainerClient(containerName);
            await container.CreateIfNotExistsAsync(PublicAccessType.Blob);
            var blob = container.GetBlobClient(fileName);
            await blob.UploadAsync(stream, overwrite: true);
        }

        public async Task DeleteFileAsync(string fileName, string containerName)
        {
            var container = _blobServiceClient.GetBlobContainerClient(containerName);
            var blob = container.GetBlobClient(fileName);
            await blob.DeleteIfExistsAsync();
        }

        public async Task UploadDirectoryAsync(string localFolderPath, string remoteFolderName, string containerName)
        {
            var container = _blobServiceClient.GetBlobContainerClient(containerName);
            await container.CreateIfNotExistsAsync(PublicAccessType.Blob);

            var files = Directory.GetFiles(localFolderPath);
            foreach (var filePath in files)
            {
                var fileName = Path.GetFileName(filePath);
                var blobPath = $"{remoteFolderName}/{fileName}";
                await using var stream = File.OpenRead(filePath);
                var blob = container.GetBlobClient(blobPath);
                await blob.UploadAsync(stream, overwrite: true);
            }
        }

        public async Task DeleteDirectoryAsync(string folderName, string containerName)
        {
            var container = _blobServiceClient.GetBlobContainerClient(containerName);
            await foreach (BlobItem blobItem in container.GetBlobsAsync(prefix: folderName + "/"))
            {
                await container.DeleteBlobIfExistsAsync(blobItem.Name);
            }
        }

        public string GetBlobUrl(string fileNameOrPath, string containerName)
        {
            return $"{_baseUrl}/{containerName}/{fileNameOrPath}";
        }
    }
}
