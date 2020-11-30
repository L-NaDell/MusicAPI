using DemoMusicAPI.Entities;
using DemoMusicAPI.Entities.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DemoMusicAPI.ApiProvider
{
    public class SongApiProvider : ISongApiProvider
    {
        private readonly ApiConfiguration _apiConfig;

        public SongApiProvider(ApiConfiguration apiConfig)
        {
            _apiConfig = apiConfig;
        }

        public async Task<List<Song>> SearchSongs(string artist)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, $"{_apiConfig.DeezerApiUrl}search?q={artist}");

            request.Headers.Add(_apiConfig.DeezerApiKey.Name, _apiConfig.DeezerApiKey.Value);
            request.Headers.Add(_apiConfig.DeezerApiHostName.Name, _apiConfig.DeezerApiHostName.Value);

            var httpResponse = await client.SendAsync(request);
            var stringResult = await httpResponse.Content.ReadAsStringAsync();

            var serializedResult = JsonConvert.DeserializeObject<ApiResponse>(stringResult);

            return serializedResult.data.ToList();
        }
    }
}
