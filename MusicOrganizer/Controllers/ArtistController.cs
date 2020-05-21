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

    [HttpPost("/artists")]
    public ActionResult Create(string name, string genre)
    {
      Artist newArtist = new Artist(name, genre);
      return RedirectToAction("Index");
    }

    [HttpGet("/artists/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpGet("/artists/{id}")]
    public ActionResult Show(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Artist selectedArtist = Artist.Find(id);
      List<Song> artistSongs = selectedArtist.Songs;
      model.Add("artist", selectedArtist);
      model.Add("songs", artistSongs);
      return View(model);
    }

    [HttpPost("/artists/{artistid}/songs")]
    public ActionResult Create(int artistId, string title)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Artist foundArtist = Artist.Find(artistId);
      Song newSong = new Song(title);
      List<Song> ArtistSongs = foundArtist.Songs;
      ArtistSongs.Add(newSong);
      model.Add("songs", ArtistSongs);
      model.Add("artist", foundArtist);
      return View("Show", model);
    }
  }
}