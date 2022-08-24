using System;
using System.Collections.Generic;
using System.IO;

namespace AoC2020.InputReaderHelpers;

public class InputToNumberList
{
    public List<int> ReadToIntArray(string day, string file)
    {
        var projectPath = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory())!.ToString())!.ToString());
        var filePath = $"{projectPath}/Days/{day}/Data/{file}.txt";

        var input = new List<int>();

        var lines = File.ReadLines(filePath);
        foreach (var line in lines)
        {
            input.Add(Int32.Parse(line));            
        }
        
        return input;
    } 
    
    public List<long> ReadToLongArray(string day, string file)
    {
        var projectPath = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory())!.ToString())!.ToString());
        var filePath = $"{projectPath}/Days/{day}/Data/{file}.txt";

        var input = new List<long>();

        var lines = File.ReadLines(filePath);
        foreach (var line in lines)
        {
            input.Add(long.Parse(line));            
        }
        
        return input;
    } 
}