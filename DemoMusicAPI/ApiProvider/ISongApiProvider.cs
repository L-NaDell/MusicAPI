using DemoMusicAPI.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DemoMusicAPI.ApiProvider
{
    public interface ISongApiProvider
    {
        Task<List<Song>> SearchSongs(string artist);
    }
}
