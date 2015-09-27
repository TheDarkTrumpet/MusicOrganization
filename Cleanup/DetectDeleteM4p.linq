<Query Kind="Statements">
  <Namespace>System.IO</Namespace>
  <Namespace>System.Text.RegularExpressions</Namespace>
</Query>

string DirectoryToParse = @"Z:\Music\Uncategorized Music\";


//ProcessDirectory(DirectoryToParse);

// Only run the following if really sure you want to do this
ProcessDirectory(DirectoryToParse, true);
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

		if (!String.IsNullOrEmpty(matchedDirectory))
		{
			Console.WriteLine("Current directory contains two types of files, skipping processing");
			//matchedDirectory = "";
		}
	}
	// Recurse into subdirectories of this directory.
	string[] subdirectoryEntries = Directory.GetDirectories(directoryName);
	foreach (string subdirectory in subdirectoryEntries)
	{
		Console.WriteLine("Processing Recursively -- Directory Found: " + subdirectory);
        ProcessDirectory(subdirectory, deleteDirectory);
	}
	Console.WriteLine("deleteDirectory => " + deleteDirectory);
	Console.WriteLine("matchedDirectory => " + matchedDirectory);
	if (deleteDirectory && !String.IsNullOrEmpty(matchedDirectory))
	{
		Console.WriteLine("Deleting directory: " + matchedDirectory);	
	
	}