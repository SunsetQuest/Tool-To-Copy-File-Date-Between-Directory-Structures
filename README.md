# Tool-To-Copy-File-Date-Between-Directory-Structures
A tool to copy the file date/time from one directory structure(or tree) to another.


## USAGE: 
CopyDirDates "Source Directory" "Destination Directory" [Options]

Options:
  "Source Directory"   The directory where to get the dates. (Quotes required if path has spaces.)
  "Dest. Directory"    The directory where the dates will be applied to. (Quotes required if path has spaces.)
  -CopyModified        Copies over the modified datetime.
  -CopyCreated         Copies over the created datetime.
  -CopyAccessed        Copies over the last Access datetime.
  -CopyAll             Same as: -CopyModified -CopyCreated -CopyAccessed
  -ExcludeSubFolders   Excludes subfolders (Top Directory Only)
  -Preview             Only displays the changes would be made applied.

## Description 
Given two nearly identical folder trees, CopyDirDates will copy over just the file dates from the source directory to the destination directory. Files not found in the source are skipped.


## Example 
CopyDirDates "C:\My Folder1" D:\Folder2 -CopyAll -Preview


##Demo
Inline-style: 
![Demo 1](https://github.com/SunsetQuest/Tool-To-Copy-File-Date-Between-Directory-Structures/Info/CopyDirDates2.gif "Demo 1")
