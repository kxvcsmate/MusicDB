namespace C8N5NZ_HFT_2022231.Models.DTOs
{
    public class AlbumStat
    {
        public string AlbumTitle { get; set; }
        public int SongCount { get; set; }

        public override bool Equals(object obj)
        {
            return obj is AlbumStat statistic &&
                   AlbumTitle == statistic.AlbumTitle &&
                   SongCount == statistic.SongCount;
        }

        public override string ToString()
        {
            return $"AlbumTitle = {AlbumTitle}, SongCount = {SongCount}";
        }
    }
}