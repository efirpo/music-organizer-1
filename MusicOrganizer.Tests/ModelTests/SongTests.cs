using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicOrganizer.Models;
using MySql.Data.MySqlClient;

namespace MusicOrganizer.Tests
{
  [TestClass]
  public class SongTests : IDisposable
  {
    public void Dispose()
    {
      Song.ClearAll();
    }

    public SongTests()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=epicodus;port=3306;database=music_organizer_test;";
    }

    [TestMethod]
    public void GetAll_ReturnsEmptyListFromDatabase_SongList()
    {
      List<Song> newList = new List<Song>{};
      List<Song> result = Song.GetAll();
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void Equals_ReturnsTrueIfTitlesAreTheSame_Song()
    {
      Song firstSong = new Song("Heaven", "Now or Never", 2020);
      Song secondSong = new Song("Heaven", "Now or Never", 2020);
      Assert.AreEqual(firstSong, secondSong);
    }

    [TestMethod]
    public void Save_SavesToDatabase_SongList()
    {
      Song testSong = new Song("Ghost", "Forever", 2014);
      testSong.Save();
      List<Song> result = Song.GetAll();
      List<Song> testList = new List<Song> {testSong};
      CollectionAssert.AreEqual(testList, result);
    }

    // [TestMethod]
    // public void SongConstructor_CreatesInstanceOfSong_Song()
    // {
    //   Song newSong = new Song("Death of a Bachelor", "D of B");
    //   Assert.AreEqual(typeof(Song), newSong.GetType());
    // }

    // [TestMethod]
    // public void SongConstructor_CreatesInstanceOfSongWithYear_Song()
    // {
    //   Song newSong = new Song("Death of a Bachelor", "D of B", 2016);
    //   Assert.AreEqual(typeof(Song), newSong.GetType());
    // }

    // [TestMethod]
    // public void GetTitle_ReturnTitle_String()
    // {
    //   string title = "Yesterday";
    //   Song newSong = new Song(title);

    //   string result = newSong.Title;

    //   Assert.AreEqual(title, result);
    // }

    [TestMethod]
    public void GetProperties_ReturnSongProperties_String()
    {
      string title = "Skyfall";
      string album = "James Bond";
      int year = 2011;
      Song newSong = new Song(title, album, year);
      newSong.Save();
      string titleResult = newSong.Title;
      string albumResult = newSong.Album;
      int yearResult = newSong.Year;
      Assert.AreEqual(title, titleResult);
      Assert.AreEqual(album, albumResult);
      Assert.AreEqual(year, yearResult);      
    }

    [TestMethod]
    public void GetAll_ReturnsSongs_SongList()
    {
      string title = "Skyfall";
      string album = "James Bond";
      int year = 2011;
      Song song1 = new Song(title, album, year);
      song1.Save();
      Song testSong = new Song("Ghost", "Forever", 2014);
      testSong.Save();
      List<Song> newList = new List<Song> {song1, testSong};
      List<Song> result = Song.GetAll();
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void Find_ReturnsCorrectSongFromDatabase_Songs()
    {
      string title = "Skyfall";
      string album = "James Bond";
      int year = 2011;
      Song song1 = new Song(title, album, year);
      song1.Save();
      Song testSong = new Song("Ghost", "Forever", 2014);
      testSong.Save();
      Song foundSong = Song.Find(song1.Id);
      Assert.AreEqual(song1, foundSong);
    }
  } 
}