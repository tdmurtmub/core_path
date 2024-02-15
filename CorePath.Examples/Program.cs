// See https://aka.ms/new-console-template for more information

using tdmm.FileSystem;

// Constructing a CorePath

Console.WriteLine("From multiple string Arguments:");
Console.WriteLine(new CorePath("System", "Lib", "README.md").ToString());

Console.WriteLine("From an array of strings:");
Console.WriteLine(new CorePath(new String[] { "System", "Lib", "README.md" }).ToString());

// Segment Name Validation across all supported Platforms (Windows, Linux, Mac)

Console.WriteLine("Valid chatacters: 'A..Z', 'a..z', '0..9', '.' (dot), '-' (dash), '_' (underscore)");
Console.WriteLine(new CorePath("A..Z", "a-z", "0_9").ToString());

Console.WriteLine("Invalid chatacters:");
try
{
    Console.WriteLine(new CorePath("Not:Valid").ToString());
}
catch (Exception ex)
{
    Console.WriteLine($"Throws: {ex.Message}");
}

