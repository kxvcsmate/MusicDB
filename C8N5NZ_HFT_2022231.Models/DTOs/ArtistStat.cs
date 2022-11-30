namespace C8N5NZ_HFT_2022231.Models.DTOs
{
    public class ArtistStat
    {
        public string ArtistName { get; set; }
        public int AlbumCount { get; set; }

        public override bool Equals(object obj)
        {
            return obj is ArtistStat statistic &&
                   ArtistName == statistic.ArtistName &&
                   AlbumCount == statistic.AlbumCount;
        }

        public override string ToString()
        {
            return $"ArtistName = {ArtistName}, AlbumCount = {AlbumCount}";
        }
    }
}