﻿

using SortingApp;
using System.IO.Abstractions;

// get the path of the file to read, from the command line
string pathArgument = Environment.GetCommandLineArgs()[1];

// Combine the path of the current directory with the name of the file to read from
string pathToWrite = Path.Combine(Directory.GetCurrentDirectory(), "sorted-names-list.txt");
string pathToRead = Path.Combine(Directory.GetCurrentDirectory(), pathArgument);

//read the file into a list
var reader = new FileReader(new FileSystem());
List<string> lines = reader.ReadFile(pathToRead);

//sort the list
Sorter.SortNamesByLastNameThenGivenName(lines);

//write the sorted list to a file
File.WriteAllLines(pathToWrite, lines);



