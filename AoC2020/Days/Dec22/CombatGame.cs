namespace AoC2020.Days.Dec22;

public class CombatGame
{

    public (Queue<int>, Queue<int>) PlayGame(Queue<int> player1, Queue<int> player2)
    {
        while (player1.Count > 0 && player2.Count > 0)
        {
            (player1, player2) =  NextRound(player1, player2);
        }
        return (player1, player2);
    }

    private (Queue<int>, Queue<int>) NextRound(Queue<int> player1, Queue<int> player2)
    {
        var playerOneValue = player1.Dequeue();
        var playerTwoValue = player2.Dequeue();

        if (playerOneValue > playerTwoValue)
        {
            player1.Enqueue(playerOneValue);
            player1.Enqueue(playerTwoValue);
        }
        else
        {
            player2.Enqueue(playerTwoValue);
            player2.Enqueue(playerOneValue);
        }
        
        return (player1, player2);
    }

    public int CalculateScore((Queue<int>, Queue<int>) result)
    {
        var winnerDeck = result.Item1.Count > 0 ? result.Item1.Reverse().ToList() : result.Item2.Reverse().ToList();
        var score = 0;
        
        for (int i = 0; i < winnerDeck.Count; i++)
        {
            score += (i + 1) * winnerDeck[i];
        }
        
        return score;
    }
}