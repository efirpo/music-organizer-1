using Microsoft.AspNetCore.Mvc;
using MusicOrganizer.Models;
using System.Collections.Generic;

namespace MusicOrganizer.Controllers
{
    public class ArtistController: Controller
    {
      
      [HttpGet("/artists")]
      public ActionResult Index()
      {
        List<Artist> allArtists = Artist.GetAll();
        return View(allArtists);
      }

      [HttpGet("/artist/new")]
      public ActionResult New()
      {
        return View();
      }

      [HttpGet("/artists")]
      public ActionResult Show(int id)
      {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Artist selectedArtist = Artist.Find(id);
        List<Song> artistSong = selectedArtist.Songs;
        model.Add("artist", selectedArtist);
        model.Add("song", artistSong);
        return View(model);
      }
    }
}