# Katas

Implementations of various code katas for fun and no profit. All are written in
C# and will have a dependency on the latest LTS release of .NET SDK and runtime.
At time of writing, this is .NET 8.0 ([download]).

## Building, testing, publishing

Use the usual `dotnet` CLI tools:

```pwsh
dotnet build && dotnet test
dotnet publish -o bin -c Release src/Dependencies
```

## Running

If you have published to `bin` as mentioned in the previous section, you can
easily run any of:
```pwsh
./bin/deps.exe print -f deps.txt
./bin/deps.exe print "A B C
B C E
C G
D A F
E F
F H
"
"A B C`nB C E`nC G`nD A F`nE F`nF H" | ./bin/deps.exe print
```

or without a published build you can pass the input to the program with
`dotnet run` in the same fashion:

```pwsh
cd src/Dependencies

dotnet run -- print -f ../../deps.txt
dotnet run -- print "A B C
B C E
C G
D A F
E F
F H
"
"A B C`nB C E`nC G`nD A F`nE F`nF H" | dotnet run -- print
```

  [download]: https://dotnet.microsoft.com/en-us/download/dotnet/8.0