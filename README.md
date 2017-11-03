# Tool-To-Copy-File-Date-Between-Directory-Structures
A tool to copy the file date/time from one directory structure(or tree) to another.

![Demo 1](https://github.com/SunsetQuest/Tool-To-Copy-File-Date-Between-Directory-Structures/blob/master/Info/CopyDirDatesDemo2.gif "Demo 1")

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

## Description 
Given two nearly identical folder trees, CopyDirDates will copy over just the file dates from the source directory to the destination directory. Files not found in the source are skipped.

## Example 
    CopyDirDates "C:\My Folder1" D:\Folder2 -CopyAll -Preview

## Download
[Download Zip](https://github.com/SunsetQuest/Tool-To-Copy-File-Date-Between-Directory-Structures/raw/master/CopyDirDatesTool.zip)  (SHA1: 03A873FFBC248FBEF91AF08CF116C6D4B12CED6B)



