<Query Kind="Statements" />

/*
	The purpose of this script is to help me to determine the largest unique authors I have in my collection.
	I define this as:
	1) A single author of a album - as in, the authors name only appears once.
	2) Ordered by the largest # of songs/albums for the user.
	This is purely a reporting function, and doesn't actually do anything specifically itself.  Manual
	intervention is useful here, since I can take care of large chunks of my uncategorized library.
	
	This script ASSUMES the following data structure under the 'directorytoparse'
	<artist>/<album>/files
*/

string DirectoryToParse = @"Z:\Music\Uncategorized Music\";

List<string> availableArtists = GetAvailableArtists(DirectoryToParse);
Console.WriteLine("Available Artists: " + availableArtists.Count());

Dictionary<string, Dictionary<string, int>> artistAlbumCount = GenerateAlbumListFromAuthors(DirectoryToParse, availableArtists);

artistAlbumCount.Dump();
}

public List<string> GetAvailableArtists(string baseDirectory)
{
	// All artists are a directory, so no files are needed.
	List<string> artists = Directory.GetDirectories(baseDirectory).Select(x => x.Replace("\r\n", "")).ToList();
	List<string> artistsToReturn = new List<string>();
	List<string> artistsToIgnore = new List<string>();

	foreach (string artist in artists)
	{
		if (artistsToIgnore.Contains(artist))
		{
			continue;
		}

		string spacedArtist = artist + " ";
		List<string> matchingArtists = artists.Where(x => x != artist && x.Contains(spacedArtist)).ToList();

		if (matchingArtists.Count > 0)
		{
			artistsToIgnore.Add(artist);
			artistsToIgnore.AddRange(matchingArtists);
			continue;
		}
		
		artistsToReturn.Add(artist);
	}

	return artistsToReturn;
}

Dictionary<string, Dictionary<string, int>> GenerateAlbumListFromAuthors(string baseDir, List<string> artists)
{
	Dictionary<string, Dictionary<string, int>> dictionaryToReturn = new Dictionary<string, System.Collections.Generic.Dictionary<string, int>>();

	foreach (string artist in artists)
	{
		string directoryToCheck = baseDir + "\\" + artist;
		List<string> albums = Directory.GetDirectories(directoryToCheck).Select(x => x.Replace("\r\n", "")).ToList();
		Dictionary<string, int> artistAlbums = new Dictionary<string, int>();
		
		foreach (string album in albums)
		{
			List<string> tracks = Directory.GetFiles(album).Select(x => x.Replace("\r\n", "")).ToList();
			if (tracks.Count > 0)
			{
				artistAlbums.Add(album, tracks.Count());
			}
		}
		dictionaryToReturn.Add(artist, artistAlbums);
	}
	return dictionaryToReturn;
