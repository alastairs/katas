﻿namespace Katas.Dependencies.Parsing;

public class StringInputParser
{
    public IEnumerable<string> Parse(string input)
    {
        return input.Split(' ');
    }
}