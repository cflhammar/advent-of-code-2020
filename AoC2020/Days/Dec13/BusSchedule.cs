namespace AoC2020.Days.Dec13;

public class BusSchedule
{
    public int FindEarliestBus(string time ,string schedule)
    {
        int timestamp = int.Parse(time);

        int[] buses = schedule.Split(",").Where(x => x != "x").Select(x => int.Parse(x)).ToArray();
        int busId = -1;
        var minWaitingTime = 100;

        foreach (var bus in buses)
        {
            int waitingTime = Math.Abs(timestamp % bus - bus);

            if (waitingTime < minWaitingTime)
            {
                busId = bus;
                minWaitingTime = waitingTime;
            }
        }

        return busId * minWaitingTime;
    }

    
    // https://www.youtube.com/watch?v=4_5mluiXF5I
    public long FindTimeOfAlignedBuses(string schedule)
    {
        var buses = schedule.Split(",").Select(x => x != "x" ? int.Parse(x) : 1).ToList();
        
        long timestamp = 0;
        long step = buses.First();
        
        for (int delay = 1; delay < buses.Count(); delay++)
        {
            var bus = buses.ElementAt(delay);
            
            while ((timestamp + delay) % bus != 0)
            { 
                timestamp += step; 
            } 
            step *= bus;
        }

        return timestamp;
    }
}