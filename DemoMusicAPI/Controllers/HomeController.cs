using DemoMusicAPI.ApiProvider;
using DemoMusicAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;

namespace DemoMusicAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISongApiProvider _songApiProvider;

        public HomeController(ISongApiProvider songApiProvider)
        {
            _songApiProvider = songApiProvider;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SearchSongsForm()
        {
            return View();
        }

        public async Task<IActionResult> SearchSongs(string artist)
        {
            var songList = await _songApiProvider.SearchSongs(artist);

            return View("SongList", songList);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
