import os

incomingDirectory = 'C:\\temp'

for subdir, dirs, files in os.walk(incomingDirectory): #What does is.walk do
    for file in files:
        #print os.path.join(subdir, file)
        filepath = subdir + os.sep + file
        print (filepath)


# File input/output
# https://www.digitalocean.com/community/tutorials/how-to-handle-plain-text-files-in-python-3

fileA = open(incomingDirectory + '/something.txt', 'w')
fileA.write("Some text")
fileA.close()


# Desired Output/Structure
""" 
C:\temp\GenreA\GenreA.m3u
C:\temp\GenreA\Artist1\Artist1.m3u
C:\temp\GenreA\Artist1\AlbumA\FileA.txt
C:\temp\GenreA\Artist1\AlbumA\FileB.txt
C:\temp\GenreA\Artist1\AlbumB\FileA.txt
C:\temp\GenreA\Artist1\AlbumB\FileB.txt
C:\temp\GenreA\Artist1\AlbumB\FileC.txt
C:\temp\GenreA\Artist2\Artist2.m3u
C:\temp\GenreA\Artist2\AlbumA\FileA.txt
C:\temp\GenreA\Artist2\AlbumA\FileB.txt
C:\temp\GenreA\Artist2\AlbumB\FileA.txt
C:\temp\GenreA\Artist2\AlbumB\FileB.txt
C:\temp\GenreA\Artist2\AlbumB\FileC.txt
"""

# M3U file (C:\temp\GenreA\GenreA.m3u)
"""
Artist1/AlbumA/FileA.txt
Artist1/AlbumA/FileB.txt
Artist1/AlbumB/FileA.txt
Artist1/AlbumB/FileB.txt
Artist1/AlbumB/FileC.txt
Artist2/...
"""

#M3U file (C:\temp\GenreA\Artist1\Artist1.m3u)
"""
AlbumA/FileA.txt
AlbumA/FileB.txt
AlbumB/FileA.txt
AlbumB/FileB.txt
AlbumB/FileC.txt
"""