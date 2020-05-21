using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicOrganizer.Models;

namespace MusicOrganizer.Tests
{
  [TestClass]
  public class SongTests : IDisposable
  {
    public void Dispose()
    {
      Song.ClearAll();
    }

    [TestMethod]
    public void SongConstructor_CreatesInstanceOfSong_Song()
    {
      Song newSong = new Song("Death of a Bachelor", "D of B");
      Assert.AreEqual(typeof(Song), newSong.GetType());
    }

    [TestMethod]
    public void SongConstructor_CreatesInstanceOfSongWithYear_Song()
    {
      Song newSong = new Song("Death of a Bachelor", "D of B", 2016);
      Assert.AreEqual(typeof(Song), newSong.GetType());
    }

    [TestMethod]
    public void GetTitle_ReturnTitle_String()
    {
      string title = "Yesterday";
      Song newSong = new Song(title);

      string result = newSong.Title;

      Assert.AreEqual(title, result);
    }

    [TestMethod]
      public void GetProperties_ReturnSongProperties_String()
    {
      string title = "Skyfall";
      string album = "James Bond";
      int year = 2011;
      Song newSong = new Song(title, album, year);
      string titleResult = newSong.Title;
      string albumResult = newSong.Album;
      int yearResult = newSong.Year;
      Assert.AreEqual(title, titleResult);
      Assert.AreEqual(album, albumResult);
      Assert.AreEqual(year, yearResult);      
    }
  } 
}