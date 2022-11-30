namespace C8N5NZ_HFT_2022231.Models.DTOs
{
    public class AVGRating
    {

        public string ArtistName { get; set; }
        public double avgRating { get; set; }

        public override bool Equals(object obj)
        {
            return obj is AVGRating statistic &&
                   ArtistName == statistic.ArtistName &&
                   avgRating == statistic.avgRating;
        }

        public override string ToString()
        {
            return $"ArtistName = {ArtistName}, AverageRating = {avgRating}";
        }
    }
}