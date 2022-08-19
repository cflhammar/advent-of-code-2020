using System;
using System.Collections.Generic;

namespace AoC2020.Days.Dec05;

public class BinarySpacePartitioner
{
    public void FindMissingSeat(List<String> boardingPasses)
    {
        var existingSeats = new List<int>();
        for (int row = 1; row < 126; row++)
        {
            for (int col = 0; col < 8; col++)
            {
                existingSeats.Add(row * 8 + col);
            }
        }

        foreach (var boardingPass in boardingPasses)
        {
            existingSeats.Remove(FindSeatValue(boardingPass));
        }
        
        foreach (var seat in existingSeats)
        {
            if (!existingSeats.Contains(seat-1) || !existingSeats.Contains(seat+1)) Console.WriteLine(seat);
        }
    }
    
    
    public int FindHighestSeatValue(List<String> boardingPasses)
    {
        int maxValue = 0;
        foreach (var boardingPass in boardingPasses)
        {
            maxValue = Math.Max(maxValue, FindSeatValue(boardingPass));
        }

        return maxValue;
    }
    
    public int FindSeatValue(string combination)
    {
        var row = FindBinaryPosition(combination.Substring(0, 7), 0, 127);
        var seat = FindBinaryPosition(combination.Substring(7, 3), 0, 7);

        return row * 8 + seat;
    }
    
    public int FindBinaryPosition(string combination, int lower, int upper)
    {
        foreach (var c in combination)
        {
            switch (c)
            {
                case 'F' or 'L':
                    upper = upper - (upper - lower) / 2 - 1;
                    break;
                case 'B' or 'R':
                    lower = lower + (upper - lower) / 2 + 1;
                    break;
            }
        }

        return lower;
    }
}