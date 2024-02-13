# CorePath

Defines a platform independent class for specifying file and/or directory resources within a hierarchical file structure.

Examples:

    using tdmurtmub.FileSystem;

    // Constructing a CorePath

    Console.WriteLine("From multiple string Arguments:");
    Console.WriteLine(new CorePath("System", "Lib", "README.md").ToString());

    Console.WriteLine("From an array of strings:");
    Console.WriteLine(new CorePath(new String[] { "System", "Lib", "README.md" }).ToString());

Output:

    From multiple string Arguments:
    System\Lib\README.md
    From an array of strings:
    System\Lib\README.md