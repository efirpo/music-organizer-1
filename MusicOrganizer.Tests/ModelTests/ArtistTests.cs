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

    [TestMethod]
    public void Equals_ReturnsTrueIfNamesAreTheSame_Artist()
    {
      Artist artistOne = new Artist("David Bowie", "Magic Space Rock");
      Artist artistTwo = new Artist("David Bowie", "Magic Space Rock");

      Assert.AreEqual(artistOne, artistTwo);
    }

    [TestMethod]

    public void Save_SavesToDatabase_ArtistList()
    {
      Artist testArtist = new Artist("David Bowie", "Magic Space Rock");

      testArtist.Save();
      List<Artist> result = Artist.GetAll();
      List<Artist> testList = new List<Artist>{testArtist};

      CollectionAssert.AreEqual(testList, result);
    }

    [TestMethod]
    public void GetAll_ReturnsArtists_ArtistList()
    {
      string name01 = "David Bowie";
      string genre01 = "Magic Space Rock";
      string name02 = "Thom Yorke";
      string genre02 = "Pretentious Space Rock";
      Artist newArtist01 = new Artist(name01, genre01);
      newArtist01.Save();
      Artist newArtist02 = new Artist(name02, genre02);
      newArtist02.Save();

      List<Artist> newList = new List<Artist> {newArtist01, newArtist02};

      List<Artist> result = Artist.GetAll();

      CollectionAssert.AreEqual(newList, result);

    }

    [TestMethod]
    public void Find_ReturnsCorrectArtistFromDatabase_Artist()
    {
      Artist newArtist = new Artist("David Bowie", "Magic Space Rock");
      newArtist.Save();
      Artist newArtist2 = new Artist("Thom Yorke", "Pretentious Space Rock");
      newArtist2.Save();

      Artist foundArtist = Artist.Find(newArtist.Id);

      Assert.AreEqual(newArtist, foundArtist);
    }

    [TestMethod]
    public void GetAll_ReturnsEmptyListFromDatabase_ArtistList()
    {
    List<Artist> newList = new List<Artist>{};
    List<Artist> result = Artist.GetAll();
    CollectionAssert.AreEqual(newList, result);
    }
  }
}