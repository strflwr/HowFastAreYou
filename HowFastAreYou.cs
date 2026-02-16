using System.Diagnostics;

class HowFastAreYou
{
    public static void Main()
    {
        var baseSentence = "The lazy programmer keeps forgetting their job";

        Console.WriteLine("This is a typing game, try to type as fast as you can");
        Console.WriteLine($"\n {baseSentence}\n");

        Console.WriteLine("Press any key to start the game");
        Console.ReadKey();
        
        Console.Clear();
        Console.WriteLine($"{baseSentence}\n");
        Console.Write("Start typing: ");
        
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        string userInput = Console.ReadLine() ?? "";
        stopwatch.Stop();
        var timeTaken = stopwatch.Elapsed;

        var errorCount = CountErrors(baseSentence, userInput);
        
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