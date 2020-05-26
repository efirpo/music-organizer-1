using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace MusicOrganizer.Models
{
  public class Song
  {
    public string Title { get; set; }
    public string Album { get; set; }
    public int Year { get; set; }

    public int Id { get; }

    public Song(string title, string album, int year)
    {
      Title = title;
      Album = album;
      Year = year;
    }

    public Song(string title, string album, int year, int id) :
      this(title, album, year)
    {
      Id = id;
    }

    public static List<Song> GetAll()
    {
      List<Song> allSongs = new List<Song>{};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM song;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while (rdr.Read())
      {
        int songId = rdr.GetInt32(3);
        string songTitle = rdr.GetString(0);
        string songAlbum = rdr.GetString(1);
        int songYear = rdr.GetInt32(2);
        Song newSong = new Song(songTitle, songAlbum, songYear, songId);
        allSongs.Add(newSong);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allSongs;
    }

    public static void ClearAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM song;";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public static Song Find(int searchId)
    {
     //refactor for DB
     Song placeholderSong = new Song("placeholder", "album", 1997);
     return placeholderSong;
    }
  }
}