namespace C8N5NZ_HFT_2022231.Models.DTOs
{
    public class AlbumLengthStat
    {

        public string AlbumTitle { get; set; }
        public int Length { get; set; }

        public override bool Equals(object obj)
        {
            return obj is AlbumLengthStat statistic &&
                   AlbumTitle == statistic.AlbumTitle &&
                   Length == statistic.Length;
        }

        public override string ToString()
        {
            return $"AlbumTitle = {AlbumTitle}, Length = {Length} min";
        }
    }
}