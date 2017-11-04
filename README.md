# Tool-To-Copy-File-Date-Between-Directory-Structures
A tool to copy the file date/time from one directory structure(or tree) to another.

![Demo 1](https://github.com/SunsetQuest/Tool-To-Copy-File-Date-Between-Directory-Structures/blob/master/Info/CopyDirDatesDemo2.gif "Demo 1")

## Description 
Given two nearly identical folder trees (or structures), this tool will copy over just the file (accessed/modified/created) dates from a source directory to a target directory. Files that cannot be found and matched up with a source file are skipped.

## Use Cases 
Some tools import a directory tree and then export it to some other folder but don't keep the accessed, modified or created intact. This tool can be used to copy over just the dates.

Say a folder structure was copied over using a command like xcopy.  After the copy  it is relized that these the dates were not copied.  If for some reason you cannot re-copy the files, maybe because the new files are already being used, then you could use this tool to copy over just the dates. 

## USAGE: 
    CopyDirDates "Source Directory" "Destination Directory" [Options]

### Options:<br>
    "Source Directory"   The directory where to get the dates. (Quotes required if path has spaces.)<br>
    "Dest. Directory"    The directory where the dates will be applied to. (Quotes required if path has spaces.)<br>
    -CopyModified        Copies over the modified datetime.<br>
    -CopyCreated         Copies over the created datetime.<br>
    -CopyAccessed        Copies over the last Access datetime.<br>
    -CopyAll             Same as: -CopyModified -CopyCreated -CopyAccessed<br>
    -ExcludeSubFolders   Excludes subfolders (Top Directory Only)<br>
    -Preview             Only displays the changes would be made applied.<br>


## Example 
    CopyDirDates "C:\My Folder1" D:\Folder2 -CopyAll -Preview
The below example would go through each file in D:\folder2 and then find the matching file(by location) in C:\My Folder1.  For example, for the file D:\Folder2\mySubFolder\myPicture.jpg  the command below would set the date(s) on this file based on the file C:\My Folder1\mySubFolder\myPicture.jpg.  

## Download
[Download (4KB)](https://github.com/SunsetQuest/Tool-To-Copy-File-Date-Between-Directory-Structures/raw/master/CopyDirDatesTool.zip)  (SHA1: 03A873FFBC248FBEF91AF08CF116C6D4B12CED6B)



