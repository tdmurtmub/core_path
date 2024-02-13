// See https://aka.ms/new-console-template for more information

using tdmurtmub.FileSystem;

// Constructing a CorePath

Console.WriteLine("From multiple string Arguments:");
Console.WriteLine(new CorePath("System", "Lib", "README.md").ToString());

Console.WriteLine("From an array of strings:");
Console.WriteLine(new CorePath(new String[] { "System", "Lib", "README.md" }).ToString());
