using Microsoft.AspNetCore.Mvc;
using MusicOrganizer.Models;
using System.Collections.Generic;

namespace MusicOrganizer.Controllers
{
  public class ArtistController : Controller
  {

    [HttpGet("/artist")]
    public ActionResult Index()
    {
      List<Artist> allArtists = Artist.GetAll();
      return View(allArtists);
    }

    [HttpPost("/artist")]
    public ActionResult Create(string name, string genre)
    {
      Artist newArtist = new Artist(name, genre);
      newArtist.Save();
      return RedirectToAction("Index");
    }

    [HttpGet("/artist/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpGet("/artist/{id}")]
    public ActionResult Show(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Artist selectedArtist = Artist.Find(id);
      model.Add("artist", selectedArtist);
      return View(model);
    }

    // [HttpPost("/artist/{artistid}/song")]
    // public ActionResult Create(int artistId, string title)
    // {
    //   Dictionary<string, object> model = new Dictionary<string, object>();
    //   Artist foundArtist = Artist.Find(artistId);
    //   Song newSong = new Song(title);
    //   List<Song> ArtistSongs = foundArtist.Songs;
    //   ArtistSongs.Add(newSong);
    //   model.Add("songs", ArtistSongs);
    //   model.Add("artist", foundArtist);
    //   return View("Show", model);
    // }
  }
}