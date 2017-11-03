/* Copyright 2017 Ryan S. White  
https://opensource.org/licenses/MIT 
Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated 
documentation files (the "Software"), to deal in the Software without restriction, including without 
limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the
Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
The above copyright notice and this permission notice shall be included in all copies or substantial portions 
of the Software.
THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED 
TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL 
THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF 
CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER 
DEALINGS IN THE SOFTWARE. */

// Description: A tool to copy the file date/time from one directory structure(or tree) to another. 
// It's a script to copy the last created/modified/accessed times from one folder to a maching folder.

using System;
using System.IO;
using static System.Console;

class Program
{
    static void Main(string[] args)
    {
        // Let's process the input parameters  
        if (args.Length < 2)
        {
            WriteLine("USAGE: CopyDirDates \"Source Directory\" \"Destination Directory\" [Options]\n\n"+
                        "Description: Given two nearly identical folder trees, CopyDirDates will copy\n"+
                        "             over just the file dates from the source directory to the \n"+
                        "             destination directory. Files not found in the source are skipped.\n"+
                        "Options: \n"+
                        "  \"Source Directory\"   The directory where to get the dates.\n" +
                        "  \"Dest. Directory\"    The directory where the dates will be applied to.\n" +
                        "                       Quotes required if path has spaces.\n" +
                        "  -CopyModified        Copies over the modified datetime.\n" +
                        "  -CopyCreated         Copies over the created datetime.\n" +
                        "  -CopyAccessed        Copies over the last Access datetime.\n" +
                        "  -CopyAll             Same as: -CopyModified -CopyCreated -CopyAccessed\n" +
                        "  -ExcludeSubFolders   Excludes subfolders (Top Directory Only)\n" +
                        "  -Preview             Only displays the changes would be made applied.\n\n"+
                        "Example: CopyDirDates \"C:\\My Folder1\" D:\\Folder2 -CopyAll -Preview\n");
            return;
        }
        bool preview = false, copyCreated = false, copyModified = false, copyAccessed = false;
        SearchOption subfolders = SearchOption.AllDirectories;
        args = Array.ConvertAll(args, x => x.ToLower());
        string sourceFolder = args[0];
        string destinationFolder = args[1];
        for (int i = 2; i < args.Length; i++)
        {
            switch (args[i])
            {
                case "-preview": preview = true; break;
                case "-copycreated": copyCreated = true; break;
                case "-copymodified": copyModified = true; break;
                case "-copyaccessed": copyAccessed = true; break;
                case "-copyall": copyCreated = true; copyModified = true; copyAccessed = true; break;
                case "-excludesubfolders": subfolders = SearchOption.TopDirectoryOnly; break;
                default: WriteLine(" Error - Unknown param: '" + args[i] + "'"); return;
            }
        }

        // Let's check to make sure the params are valid
        if (!Directory.Exists(sourceFolder))
        { WriteLine(" Error - Could not source folder: " + sourceFolder); return; }
        if (!Directory.Exists(destinationFolder))
        { WriteLine(" Error - Could not destination folder: " + destinationFolder); return; }
        if (!copyCreated && !copyModified && !copyAccessed)
        { WriteLine(" Error: At least one copy param must be specified: -CopyModified -CopyCreated -CopyAccessed"); return; }

        CopyDates(sourceFolder, destinationFolder, copyCreated, copyModified, copyAccessed, subfolders, preview);
    }

    private static void CopyDates(string sourceFolder, string destinationFolder, bool copyCreated, bool copyModified, bool copyAccessed, SearchOption searchOptions, bool preview)
    {
        foreach (string destFile in Directory.GetFiles(destinationFolder, "*.*", searchOptions))
        {
            string sourceFile = destFile.Replace(destinationFolder, sourceFolder);
            try
            {
                if (!File.Exists(sourceFile))
                { WriteLine(" Warning - Source file not found. Skipping file: " + sourceFile); continue; }

                if (copyCreated)
                {
                    DateTime createdTime = File.GetCreationTime(sourceFile);
                    if (preview)
                        WriteLine("Copy Created(" + createdTime + ")  " + sourceFile + " -> " + destFile);
                    else
                        File.SetCreationTime(destFile, createdTime);
                }
                if (copyModified)
                {
                    DateTime modifiededTime = File.GetLastWriteTime(sourceFile);
                    if (preview)
                        WriteLine("Copy Modified(" + modifiededTime + ") from " + sourceFile + " -> " + destFile);
                    else
                        File.SetLastWriteTime(destFile, modifiededTime);
                }
                if (copyAccessed)
                {
                    DateTime accessedTime = File.GetLastAccessTime(sourceFile);
                    if (preview)
                        WriteLine("Copy Accessed(" + accessedTime + ") from " + sourceFile + " -> " + destFile);
                    else
                        File.SetLastAccessTime(destFile, accessedTime);
                }
            }
            catch (Exception e)
            {
                WriteLine(" Error with file '" + sourceFile + "' : " + e.Message);
            }
        }
    }
}