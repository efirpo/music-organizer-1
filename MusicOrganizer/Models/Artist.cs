using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace MusicOrganizer.Models
{
  public class Artist
  {
    public string Name { get; set; }
    public string Genre { get; set; }
    public int Id { get; }
    // public List<Song> Songs { get; set; }

  public Artist(string name, string genre)
  {
    Name = name;
    Genre = genre;
  }
    public Artist(string name, string genre, int id)
    {
      Name = name;
      Genre = genre;
      // Songs = new List<Song>{};
      Id = id;
    }

    public static List<Artist> GetAll()
    {
      List<Artist> allArtists = new List<Artist>{};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"Select * FROM artist;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while (rdr.Read())
      {
        int artistId = rdr.GetInt32(2);
        string artistName = rdr.GetString(0);
        string artistGenre = rdr.GetString(1);
        Artist newArtist = new Artist(artistName, artistGenre, artistId);
        allArtists.Add(newArtist);
      }
              conn.Close();
        if (conn != null)
        {
            conn.Dispose();
        }
        return allArtists;

    }

    public static Artist Find(int artistId)
    {
    // Temporarily returning placeholder item to get beyond compiler errors until we refactor to work with database.
    Artist placeholderArtist = new Artist("Lil Jessy,", "Norwegian Black Metal");
    return placeholderArtist;
  }
   

    public static void ClearAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM artist;";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
      conn.Dispose();
      }
    }

    // public void AddSong(Song song)
    // {
    //   Songs.Add(song);
    // }
  }
  }
