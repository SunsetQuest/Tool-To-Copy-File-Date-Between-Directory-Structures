// Created by Ryan White on 11/2/2017 for the world.

// A tool to copy the file date/time from one directory structure(or tree) to another. 
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
            WriteLine(@"CopyDates ""Source Directory"" ""Destination Directory"" -CopyModified -CopyCreated -CopyAccessed -ExcludeSubFolders -Preview");
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
                        WriteLine("Copy Created(" + createdTime + ")  " + sourceFile + " -> " + createdTime);
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