__all__ = ["createm3ulib"]

import os
from os import path

class createm3ulib:
    def __init__(self, basedir):
        if(path.exists(basedir) == False):
            raise Exception(RuntimeError, 'Base Directory does not exist')
        self.basedir = basedir
        self.file_exclude = ['.DS_Store', '.m3u']

    def do(self):
        current_dir = ''
        found_files = []
        for subdir, dirs, files in os.walk(self.basedir):
            for file in files:
                if(subdir == self.basedir):
                    continue
                parent_dir = self.get_parentdir(subdir)
                if(len(found_files) == 0 and parent_dir != current_dir):
                    current_dir = parent_dir
                #print("Current Dir: " + current_dir + " Parent Dir: " + parent_dir)
                if(current_dir != parent_dir):
                    self.save_m3u(current_dir, found_files)
                    found_files = []
                    current_dir = parent_dir

                #print("Subdir: " + subdir)
                # print os.path.join(subdir, file)
                filepath = subdir + os.sep + file
                file_ext = self.get_extension(filepath)

                if(file_ext not in self.file_exclude and file not in self.file_exclude):
                    found_files.append(filepath)
                # print(filepath)

    def get_parentdir(self, directory):
        return '/'.join(directory.split('/')[0:-1])

    def save_m3u(self, basedir, files):
        print("In save operation - basedir: " + basedir + " - Length: " + str(len(files)))

    def get_extension(self, filename):
        filename, file_extension = os.path.splitext(filename)
        return file_extension