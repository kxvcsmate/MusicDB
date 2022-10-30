using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C8N5NZ_HFT_2022231.Models
{
    public class Artist
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ArtistId { get; set; }
        [Required]
        [StringLength(240)]
        public string Name { get; set; }

        public Artist()
        {

        }
        public Artist(string line)
        {
            string[] split = line.Split('#');
            ArtistId = int.Parse(split[0]);
            Name = split[1];
        }
    }
}
