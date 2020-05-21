using System.Collections.Generic;

namespace MusicOrganizer.Models
{
  public class Artist
  {
    public string Name { get; set; }
    public string Genre { get; set; }
    public int Id { get; }
    private static List<Artist> _instances = new List<Artist> {};
    public List<Song> Songs { get; set; }

    public Artist(string name, string genre)
    {
      Name = name;
      Genre = genre;
      _instances.Add(this);
      Id = _instances.Count;
      Songs = new List<Song>{};
    }

    public static List<Artist> GetAll()
    {
      return _instances;
    }

    public static Artist Find(int artistId)
    {
      return _instances[artistId -1];
    }

    public static void ClearAll()
    {
      _instances.Clear();
    }

    public void AddSong(Song song)
    {
      Songs.Add(song);
    }
  }
}