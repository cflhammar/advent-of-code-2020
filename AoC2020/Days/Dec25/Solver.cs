using AoC2020.InputReaderHelpers;

namespace AoC2020.Days.Dec25;

public class Solver : IDaySolver
{
    public string Date { get; } = "";

    public void PartOne()
    {
        var testInput = new []{"5764801", "17807724"};
        var input = new[] {"17607508", "15065270"};

        var rfid = new RFIDEncryption();
        Console.WriteLine("Part 1: Test1 : " + rfid.GetEncryptionKey(testInput) +" (14897079)");
        Console.WriteLine("Part 1: " + rfid.GetEncryptionKey(input));


    }

    public void PartTwo()
    {
        
    }

    private dynamic ParseInput(string filename)
    {
        var reader = new ConsolidatedInputReader();
        
        return true;
    }
}