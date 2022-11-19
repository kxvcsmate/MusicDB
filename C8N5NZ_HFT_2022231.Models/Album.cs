using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace C8N5NZ_HFT_2022231.Models
{
    public class Album
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AlbumId { get; set; }
        [StringLength(240)]
        public string AlbumTitle { get; set; }
        [Range(0, 100)]
        public double Rating { get; set; }
        public int Release { get; set; }
        [ForeignKey(nameof(Artist))]
        public int ArtistId { get; set; }

        public virtual Artist Artist { get; set; }
        public virtual ICollection<Song> Songs { get; set; }
        public Album()
        {
            Songs = new HashSet<Song>();
        }
        public Album(string line)
        {
            string[] split = line.Split('#');
            AlbumId = int.Parse(split[0]);
            AlbumTitle = split[1];
            ArtistId = int.Parse(split[2]);
            Release = int.Parse(split[3]);
            Rating = double.Parse(split[4]);
            Songs = new HashSet<Song>();
        }
    }
}
