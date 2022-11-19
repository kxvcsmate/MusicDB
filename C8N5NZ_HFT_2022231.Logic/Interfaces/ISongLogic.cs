using C8N5NZ_HFT_2022231.Models;
using System.Collections.Generic;
using System.Linq;

namespace C8N5NZ_HFT_2022231.Logic.Interfaces
{
    public interface ISongLogic
    {
        IEnumerable<KeyValuePair<string, int>> AlbumByLength();
        void Create(Song item);
        void Delete(int id);
        Song Read(int id);
        IQueryable<Song> ReadAll();
        void Update(Song item);
    }
}