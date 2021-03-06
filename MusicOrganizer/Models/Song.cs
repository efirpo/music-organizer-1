using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace MusicOrganizer.Models
{
  public class Song
  {
    public string Title { get; set; }
    public string Album { get; set; }
    public int Year { get; set; }
    public string SongArtist { get; set; }

    public int Id { get; set; }

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

    public Song(string title, string album, int year, string songArtist) :
     this(title, album, year)
    {
      SongArtist = songArtist;
    }

    public Song(string title, string album, int year, int id, string songArtist) :
      this(title, album, year, id)
    {
      SongArtist = songArtist;
    }

    public override bool Equals(System.Object otherSong)
    {
      if (!(otherSong is Song))
      {
        return false;
      }
      else
      {
        Song newSong = (Song)otherSong;
        bool titleEquality = (this.Title == newSong.Title);
        bool idEquality = (this.Id == newSong.Id);
        bool albumEquality = (this.Album == newSong.Album);
        bool yearEquality = (this.Year == newSong.Year);
        bool artistEquality = (this.SongArtist == newSong.SongArtist);
        return (idEquality && albumEquality && yearEquality && titleEquality && artistEquality);
      }
    }

    public static List<Song> GetAll()
    {
      List<Song> allSongs = new List<Song> { };
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
        System.Console.WriteLine(songAlbum);
        System.Console.WriteLine("ALBUM WOoOOOOOOOOOOO");
        string songArtist = rdr.GetString(4);
        System.Console.WriteLine(songArtist);
        System.Console.WriteLine("ARTIST YAY!!!!!!!!!!!!!!!");
        Song newSong = new Song(songTitle, songAlbum, songYear, songId, songArtist);
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
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM `song` WHERE id = @thisId;";
      MySqlParameter thisId = new MySqlParameter();
      thisId.ParameterName = "@thisId";
      thisId.Value = searchId;
      cmd.Parameters.Add(thisId);
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      int songId = 0;
      string songTitle = "";
      string songAlbum = "";
      int songYear = 0;
      string songArtist = "";
      while (rdr.Read())
      {
        songId = rdr.GetInt32(3);
        songTitle = rdr.GetString(0);
        songAlbum = rdr.GetString(1);
        songYear = rdr.GetInt32(2);
        songArtist = rdr.GetString(4);
      }
      Song foundSong = new Song(songTitle, songAlbum, songYear, songId, songArtist);
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return foundSong;
    }

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO song (title, album, year, song_artist) VALUES (@SongTitle, @SongAlbum, @SongYear, @SongArtist);";
      MySqlParameter title = new MySqlParameter();
      title.ParameterName = "@SongTitle";
      title.Value = this.Title;
      cmd.Parameters.Add(title);
      MySqlParameter album = new MySqlParameter();
      album.ParameterName = "@SongAlbum";
      album.Value = this.Album;
      cmd.Parameters.Add(album);
      MySqlParameter year = new MySqlParameter();
      year.ParameterName = "@SongYear";
      year.Value = this.Year;
      cmd.Parameters.Add(year);
      MySqlParameter song_artist = new MySqlParameter();
      song_artist.ParameterName = "@SongArtist";
      cmd.Parameters.Add(song_artist);
      cmd.ExecuteNonQuery();
      Id = (int)cmd.LastInsertedId;
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }
  }
}