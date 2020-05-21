using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicOrganizer.Models;
using System.Collections.Generic;
using System;

namespace MusicOrganizer.Tests
{
  [TestClass]
  public class ArtistTest : IDisposable
  {
    public void Dispose()
    {
      Artist.ClearAll();
    }

    [TestMethod]
    public void ArtistConstructor_CreateArtistInstance_Object()
    {
      Artist newArtist = new Artist("P!ATD", "Pop Punk");
      Assert.AreEqual(typeof(Artist), newArtist.GetType());
    }

    [TestMethod]
    public void GetName_ReturnsName_String()
    {
      string name = "P!ATD";
      Artist newArtist = new Artist(name, "Pop Punk");
      string result = newArtist.Name;
      Assert.AreEqual(name, result);
    }

    [TestMethod]
    public void GetGenre_ReturnsGenre_String()
    {
      string name = "P!ATD";
      string genre = "Pop Punk";
      Artist newArtist = new Artist(name, genre);
      string result = newArtist.Genre;
      Assert.AreEqual(genre, result);
    }

    [TestMethod]
    public void GetAll_ReturnsAllArtists_ArtistList()
    {
      string name1 = "P!ATD";
      string genre1 = "Pop Punk";
      string name2 = "Beetles";
      string genre2 = "Rock";
      Artist newArtist1 = new Artist(name1, genre1);
      Artist newArtist2 = new Artist(name2, genre2);
      List<Artist> newList = new List<Artist> { newArtist1, newArtist2 };
      List<Artist> result = Artist.GetAll();
      CollectionAssert.AreEqual(newList, result);
    }
  }
}