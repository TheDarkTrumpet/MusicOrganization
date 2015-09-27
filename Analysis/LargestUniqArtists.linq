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
