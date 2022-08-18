using System;
using System.Collections.Generic;
using System.IO;

namespace AoC2020.InputReaderHelpers;

public class InputToStringArray
{
    public List<String> ReadToStringArray(string day, string file)
    {
        var projectPath = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory())!.ToString())!.ToString());
        var filePath = $"{projectPath}/Days/{day}/Data/{file}.txt";

        var input = new List<String>();

        var lines = File.ReadLines(filePath);
        foreach (var line in lines)
        {
            input.Add(line);            
        }
        
        return input;
    } 
}