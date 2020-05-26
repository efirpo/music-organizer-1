using Microsoft.AspNetCore.Mvc;
using MusicOrganizer.Models;
using System.Collections.Generic;

namespace MusicOrganizer.Controllers
{
  public class SongController: Controller
  {
    [HttpGet("/artist/{artistId}/song/new")]
    public ActionResult New(int artistId)
    {
      Artist artist = Artist.Find(artistId);
      artist.Save();
      return View(artist);
    }

    [HttpGet("/artist/{artistId}/song/{songId}")]
    public ActionResult Show(int artistId, int songId)
    {
      Song song = Song.Find(songId);
      song.Save();
      Artist artist = Artist.Find(artistId);
      artist.Save();
      Dictionary<string, object> model = new Dictionary<string, object>();
      model.Add("song", song);
      model.Add("artist", artist);
      return View(model);
    }

    [HttpPost("/song/delete")]
    public ActionResult DeleteAll()
    {
      Song.ClearAll();
      return View();
    }   

  }
}
