using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C8N5NZ_HFT_2022231.Models
{
    public class Song
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SongId { get; set; }
        [StringLength(240)]
        public string SongTitle { get; set; }
        [Range(1, 10)]
        public int Length { get; set; }
        [ForeignKey(nameof(Album))]
        public int AlbumId { get; set; }
        public virtual Artist Album { get; set; }

        public Song()
        {

        }
        public Song(string line)
        {
            string[] split = line.Split('#');
            SongId = int.Parse(split[0]);
            SongTitle = split[1];
            Length = int.Parse(split[2]);
            AlbumId = int.Parse(split[3]);
        }
    }
}
