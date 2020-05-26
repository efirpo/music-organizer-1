using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace MusicOrganizer.Models
{
  public class Artist
  {
    public string Name { get; set; }
    public string Genre { get; set; }
    public int Id { get; set; }
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

    public override bool Equals(System.Object otherArtist)
    {
      if (!(otherArtist is Artist))
      {
        return false;
      }
      else
      {
        Artist newArtist = (Artist) otherArtist;
        bool nameEquality = (this.Name == newArtist.Name);
        bool genreEquality = (this.Genre == newArtist.Genre);
        bool idEquality = (this.Id == newArtist.Id);
        return (nameEquality && genreEquality && idEquality);
      }
    }
      public void Save()
     {
        MySqlConnection conn = DB.Connection();
        conn.Open();
        var cmd = conn.CreateCommand() as MySqlCommand;

        // Begin new code

        cmd.CommandText = @"INSERT INTO artist (name, genre) VALUES (@ArtistName, @ArtistGenre);";
        MySqlParameter name = new MySqlParameter();
        MySqlParameter genre = new MySqlParameter();
        name.ParameterName = "@ArtistName";
        name.Value = this.Name;
        cmd.Parameters.Add(name);
        genre.ParameterName="@ArtistGenre";
        genre.Value = this.Genre;
        cmd.Parameters.Add(genre);    
        cmd.ExecuteNonQuery();
        Id = (int) cmd.LastInsertedId;

        // End new code

        conn.Close();
        if (conn != null)
        {
          conn.Dispose();
        }
      }

    public static List<Artist> GetAll()
    {
      List<Artist> allArtists = new List<Artist>{};
      MySqlConnection conn = DB.Connection();
      conn.Open(); 
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM artist;";
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

    public static Artist Find(int id)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM `artist` WHERE id = @thisId;";
      MySqlParameter thisId = new MySqlParameter();
      thisId.ParameterName = "@thisId";
      thisId.Value = id;
      cmd.Parameters.Add(thisId);
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      int artistId = 0;
      string artistName = "";
      string artistGenre = "";
      while (rdr.Read())
      {
        artistId = rdr.GetInt32(2);
        artistName = rdr.GetString(0);
        artistGenre = rdr.GetString(1);
      }
      Artist foundArtist = new Artist(artistName, artistGenre, artistId);

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return foundArtist;

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
