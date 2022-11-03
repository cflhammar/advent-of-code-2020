namespace AoC2020.Days.Dec22;

public class RecursiveCombatGame
{
    

    public (Queue<int>, Queue<int>) PlayGame(Queue<int> player1, Queue<int> player2, int level = 0)
    {
        List<string> memory = new List<string>();
        var rounds = 0;
            
        while (player1.Count > 0 && player2.Count > 0)
        {
            rounds++;
            
            //memorize one player deck is sufficient
            var gameId = string.Join(",", player1); //+ ":" + string.Join(",", player2);

            // check for infinite loop
            if (memory.Contains(gameId) ) 
            {
                while (player2.Count > 0)
                {
                    player1.Enqueue(player2.Dequeue());
                }
                return (player1, player2);
            }
            
            var player1Peek = player1.Peek();
            var player2Peek = player2.Peek();

            if (player1.Count - 1 >= player1Peek && player2.Count - 1 >= player2Peek)
            {
                var player1Draw = player1.Dequeue();
                var player2Draw = player2.Dequeue();

                var player1SubDeck = new Queue<int>(player1.Take(player1Draw));
                var player2SubDeck = new Queue<int>(player2.Take(player2Draw));
                
                (player1SubDeck, player2SubDeck) = PlayGame(player1SubDeck, player2SubDeck, level + 1);
                if (player1SubDeck.Count > player2SubDeck.Count)
                {
                    player1.Enqueue(player1Draw);
                    player1.Enqueue(player2Draw);
                }
                else
                {
                    player2.Enqueue(player2Draw);
                    player2.Enqueue(player1Draw);
                }
            }
            else
            {
                (player1, player2) = NextRound(player1, player2);
            }
            
            memory.Add(gameId);
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
        var regulatCombatGame = new CombatGame();
        return regulatCombatGame.CalculateScore(result);
    }
}