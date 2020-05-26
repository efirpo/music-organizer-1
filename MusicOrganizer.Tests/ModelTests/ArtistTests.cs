using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicOrganizer.Models;
using System.Collections.Generic;
using System;
using MySql.Data.MySqlClient;

namespace MusicOrganizer.Tests
{
  [TestClass]
  public class ArtistTest : IDisposable
  {
    public void Dispose()
    {
      Artist.ClearAll();
    }
    public ArtistTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=epicodus;port=3306;database=music_organizer_test;";
    }

    // [TestMethod]
    // public void ArtistConstructor_CreateArtistInstance_Object()
    // {
    //   Artist newArtist = new Artist("P!ATD", "Pop Punk");
    //   Assert.AreEqual(typeof(Artist), newArtist.GetType());
    // }

    // [TestMethod]
    // public void GetName_ReturnsName_String()
    // {
    //   string name = "P!ATD";
    //   Artist newArtist = new Artist(name, "Pop Punk");
    //   string result = newArtist.Name;
    //   Assert.AreEqual(name, result);
    // }

    // [TestMethod]
    // public void GetGenre_ReturnsGenre_String()
    // {
    //   string name = "P!ATD";
    //   string genre = "Pop Punk";
    //   Artist newArtist = new Artist(name, genre);
    //   string result = newArtist.Genre;
    //   Assert.AreEqual(genre, result);
    // }

    [TestMethod]
    public void GetAll_ReturnsEmptyListFromDatabase_ArtistList()
    {
    List<Artist> newList = new List<Artist>{};
    List<Artist> result = Artist.GetAll();
    CollectionAssert.AreEqual(newList, result);
    }
  }
}