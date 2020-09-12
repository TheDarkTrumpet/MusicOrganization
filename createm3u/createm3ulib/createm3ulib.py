__all__ = ["createm3ulib"]

import os

class createm3ulib:
    def __init__(self, basedir):
        self.basedir = basedir

    def do(self):
        for subdir, dirs, files in os.walk(self.basedir):
            for file in files:
                # print os.path.join(subdir, file)
                filepath = subdir + os.sep + file
                print(filepath)
