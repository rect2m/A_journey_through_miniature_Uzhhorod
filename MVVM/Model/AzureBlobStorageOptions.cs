namespace A_journey_through_miniature_Uzhhorod.MVVM.Model
{
    public class AzureBlobStorageOptions
    {
        public string ConnectionString { get; set; } = string.Empty;
        public string ImageContainer { get; set; } = string.Empty;
        public string ModelContainer { get; set; } = string.Empty;
        public string AvatarContainer { get; set; } = string.Empty;
    }

}
