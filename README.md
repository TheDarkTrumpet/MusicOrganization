# MusicOrganization


## Language and Requirements
This entire project is developed using a combination of C# and F# code.  There may be some projects, that you can load within Visual Studio, but the majority of it are scripts that I've run using LinqPad.

To those developers unfamiliar with Linqpad, you can read more about it at [https://www.linqpad.net].  If you're a .NET developer, LinqPad is the closest thing you can get to a REPL (Read, Evaluate, Print, Loop), even though it's not even close to a REPL.  Still, it's by far one of the best tools I've used.  It's also free, but some of my scripts may require NuGet packages.  I'll denote them in the package if they use NuGet packages.  The free version of Linqpad may allow these to be downloaded.

## Synopsis and Reasons for This Project
Have you ever tried to organize your music library?  Maybe your music library is already pristine, but my guess is a lot of people have very messy libraries.  With the purchase of the [http://www.fiio.net/en/products/41](Fiio X5 2nd generation) recently, I have a growing desire to clean up, and fix my library...but not only that, but to allow for a simple solution that allows me to manage the X5 through the use of scripts.

I was surprised by the total lack of available resources out there...or maybe better stated, a lack of resources that offered the flexibility I needed in matching my library.  Because of this, I am somewhat forced to develop my own set of scripts.

## Structure and Assumptions
You will *very  unlikely* be able to use these scripts in the form I present them.  That's okay, and I encourage people to only use these as a jumping start for developing their own scripts.  Here, I will try and give a general outline of my own requirements, and what this repository will likely contain when finished (I will update this line when it is finished).

### Directory Structure
The directory structure I try and follow, for much of my library is the following:

Genre/Artist/Album

I also try and not allow an album to go over multiple artists.  If an album has different artists for one album, I want it to go into a 'Various' directory.

I listen to a lot of video game music, and in those cases, I'm not necessarily interested in keeping the above structure.  Currently, as of this writing, I have the structure of:

Genre/GameName/

This will likely change to the first convention.

### Features Needed
1.  The ability to get album artwork, somehow, but in a semi-automated way.
2.  The ability to retag EVERYTHING, based off the directory structure I want.  By everything, I mean MP3/FLAC/OGG/M4A.  This includes the images for albums (whcih I want all albums to have)
3.  RSync scripts to push information to the remote device.  The remote device in this case could be the X5, or on-board storage.  My goal is to eventually have one source of my data, only one, and everything gets pulled from this resource.  Any new music goes to the source, immediately, or to a temporary location til I can get it to the source.  This is mostly convention I'm focusing on here.
4.  The ability to index information about my library.  Specifically, after everything has been tagged properly, I want to generate a report that shows the bitrate of various albums.  The goal is to allow me to upgrade/rerip specific albums depending on what I find.  This can also allow me to prune my library.

### Long-term goals
Along with what I mentioned in the above section, I also want to make use of iTunes' album matching service to upload albums that are of lower bitrate, and attempt to upgrade those albums specifically.

## Where you can help
If you stumble across this, and it's still in active development (which will be for awhile - and I'll update this line when that changes), feel free to post bugs and pull requests.  I am a bit focused on code quality, repeatability, and overall features.  If you implement features, I'll probably pull it in then make it similar to the rest of the features here, just to newer people have to do less context switching.  If it's refactoring existing code, I'll likely test it before incorporating it totally.

Comments are helpful, feel free to make an issue if you want something specifically addressed.
