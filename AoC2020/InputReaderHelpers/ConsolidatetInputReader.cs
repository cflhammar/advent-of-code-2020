using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AoC2020.InputReaderHelpers;

public class ConsolidatedInputReader
{
    public string GetFileContent(string day, string file)
    { 
        var projectPath = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory())!.ToString())!.ToString());
        var filePath = $"{projectPath}/Days/{day}/Data/{file}.txt";
        var text = File.ReadAllText(filePath);

        return text;
    }
    
    
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



    public List<string> SplitByEmptyRow(string day, string file)
    {
        var text = GetFileContent(day, file);
        var lines = text.Split("\n\n").ToList();

        return lines;
    }

    public List<List<string>> SplitListOfStringToListListOfStringByRow(List<string> input)
    {
        var output = new List<List<string>>();
        
        foreach (var line in input)
        {
            output.Add(line.Split("\n").ToList());
        }

        return output;
    }
}