using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AoC2020.InputReaderHelpers;

public class InputToStringMatrixEmptyRowAsDelimiter
{
    public List<List<String>> ReadToStringMatrix(string day, string file, string delimiter)
    {
        var projectPath = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory())!.ToString())!.ToString());
        var filePath = $"{projectPath}/Days/{day}/Data/{file}.txt";

        var input = new List<List<String>>();

        var text = File.ReadAllText(filePath);
        var lines = text.Split("\n\n");

        foreach (var line in lines)
        {
            input.Add(line.Split(new Char[] {' ','\n'}).ToList());
        }
        
        return input;
    } 
}