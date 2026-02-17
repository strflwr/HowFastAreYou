using System.Diagnostics;

class HowFastAreYou
{
    public static void Main()
    {
        List<string> baseSentence = new List<string> 
        { 
            "lazy", "programmer", "will", "would", "because", 
            "keyboard", "of", "from", "the", "and", "since" 
        };

        Random rand = new Random();
        var numberOfWords = 10; 
        List<string> randomWords = new List<string>();

        for (var i = 0; i < numberOfWords; i++)
        {
            var index = rand.Next(baseSentence.Count); 
            randomWords.Add(baseSentence[index]);
        }
        
        string sentenceToType = string.Join(" ", randomWords);

        Console.WriteLine("This is a typing game, try to type as fast as you can");
        Console.WriteLine($"\n{sentenceToType}\n");

        Console.WriteLine("Press any key to start the game");
        Console.ReadKey();
        
        Console.Clear();
        Console.WriteLine($"{sentenceToType}\n");
        Console.Write("Start typing: ");
        
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        string userInput = Console.ReadLine() ?? "";
        stopwatch.Stop();
        var timeTaken = stopwatch.Elapsed;

        var errorCount = CountErrors(sentenceToType, userInput);
        
        Console.WriteLine("\n--- Results ---");
        Console.WriteLine($"Total time: {timeTaken.TotalSeconds:F2}s");
        Console.WriteLine($"Total errors: {errorCount}");
    }

    private static int CountErrors(string original, string typed)
    {
        var errors = 0;
        var minLength = Math.Min(original.Length, typed.Length);

        for (var i = 0; i < minLength; i++)
        {
            if (original[i] != typed[i])
                errors++;
        }
        errors += Math.Abs(original.Length - typed.Length);
        return errors;
    }
}
