<Query Kind="Statements">
  <Namespace>System.IO</Namespace>
  <Namespace>System.Text.RegularExpressions</Namespace>
</Query>

/*
   The purpose of this file is to clean up the .m4p files I have in a folder, recursively.
   Apple's iTunes has a weird directory structure that consists of AlbumArtist/Album
   But M4P files are unable to be run on anything but iTunes, unless you break the DRM.
   Apple, though, allows for upgrading one's library (iTunes Matching - $25.00 a year).
   While annoying to have to pay, it's better than it used to be.  Needless to say, since I can pull
   everything directly from iTunes again, deleting this is perfectly okay.
*/

string DirectoryToParse = @"Z:\Music\Uncategorized Music\";


//ProcessDirectory(DirectoryToParse);

// Only run the following if really sure you want to do this
ProcessDirectory(DirectoryToParse, true);

// Cleanup Empty Directories
// Before running this, you must run the following on your directory to cleanup
// find . -type f -name '.DS_Store' -exec rm {} \;
ProcessEmptyDirectory(DirectoryToParse, true);
}

void ProcessDirectory(string directoryName, bool deleteDirectory = false)
{
	// Process the list of files found in the directory.
	string[] fileEntries = Directory.GetFiles(directoryName);
	string matchedDirectory = "";
	foreach (string fileName in fileEntries)
	{
		if (Regex.Match(fileName, @".*?\.m4p$").Success)
		{
			Console.WriteLine("File Found: " + fileName);
			matchedDirectory = directoryName;
			continue;
		}
	}
	// Recurse into subdirectories of this directory.
	string[] subdirectoryEntries = Directory.GetDirectories(directoryName);
	foreach (string subdirectory in subdirectoryEntries)
	{
		Console.WriteLine("Processing Recursively -- Directory Found: " + subdirectory);
		ProcessDirectory(subdirectory, deleteDirectory);
	}

	if (deleteDirectory && !String.IsNullOrEmpty(matchedDirectory))
	{
		Console.WriteLine("Deleting directory: " + matchedDirectory);
		Directory.Delete(matchedDirectory, true);
	}
}

void ProcessEmptyDirectory(string directoryName, bool deleteDirectory = false)
{
	// Process the list of files found in the directory.
	string[] fileEntries = Directory.GetFiles(directoryName);
	string matchedDirectory = "";
	
	// Recurse into subdirectories of this directory.
	string[] subdirectoryEntries = Directory.GetDirectories(directoryName);