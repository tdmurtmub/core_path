# CorePath

Defines a platform independent class for specifying file and/or directory resources within a hierarchical file structure.

## Constructing a CorePath

### From multiple String Arguments

    var path = new CorePath("System", "Lib", "README.md");
    Console.WriteLine(path.ToString()); 
    
would display:

    System\Lib\README.md
