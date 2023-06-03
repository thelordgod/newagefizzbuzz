using System.Diagnostics;

public static class Program
{
    public static void Main()
    {
        var iterations = 5000000;
        long time = 0;
        var cycles = 2;
        for (int i = 0; i < cycles; i++)
        {
            time += FizzBuzzFastest(iterations);
            // time += FizzBuzzModuloLess(iterations);
            // time += FizzBuzz(iterations);
        }

        Console.WriteLine($"Average time for {iterations} iterations: {time / cycles}ms");
    }

    public static long FizzBuzz(int maxIterations)
    {
        var stopwatch = new Stopwatch();
        var iteration = 1;

        var fizzDict = new Dictionary<string, int>()
        {
            { "Fizz", 31 },
            { "Buzz", 59 },
            { "Bazz", 127 },
            { "Bezz", 19 },
            { "Bizz", 91 },
        };
        stopwatch.Start();

        while (iteration <= maxIterations)
        {
            var result = "";

            foreach (var divisor in fizzDict)
            {
                if (iteration % divisor.Value == 0)
                {
                    result += divisor.Key;
                }
            }

            if (result == "")
            {
                result = iteration.ToString();
            }

            // Console.WriteLine(result);

            iteration++;
        }

        stopwatch.Stop();
        Console.WriteLine(stopwatch.ElapsedMilliseconds);
        return stopwatch.ElapsedMilliseconds;
    }

    public class CustomFizzBuzz
    {
        public string Name { get; private set; }
        public int Value { get; private set; }
        public int NextMultiple { get; private set; }

        public CustomFizzBuzz(string name, int value)
        {
            Name = name;
            Value = value;
            NextMultiple = value;
        }

        public void UpdateNextMultiple()
        {
            NextMultiple += Value;
        }
    }

    public static long FizzBuzzFastest(int maxIterations)
    {
        var stopwatch = new Stopwatch();
        var iteration = 1;

        var fizzList = new List<CustomFizzBuzz>()
        {
            new CustomFizzBuzz("Fizz", 31),
            new CustomFizzBuzz("Buzz", 59),
            new CustomFizzBuzz("Bazz", 127),
            new CustomFizzBuzz("Bezz", 19),
            new CustomFizzBuzz("Bizz", 91)
        };

        stopwatch.Start();

        while (iteration <= maxIterations)
        {
            var result = "";
            foreach (var fizzBuzz in fizzList)
            {
                if (iteration == fizzBuzz.NextMultiple)
                {
                    result += fizzBuzz.Name;
                    fizzBuzz.UpdateNextMultiple();
                }
            }

            if (result == "")
            {
                result = iteration.ToString();
            }

            // Console.WriteLine(result);

            iteration++;
        }


        stopwatch.Stop();
        Console.WriteLine(stopwatch.ElapsedMilliseconds);
        return stopwatch.ElapsedMilliseconds;
    }

    public static long FizzBuzzModuloLess(int maxIterations)
    {
        var stopwatch = new Stopwatch();
        var iteration = 1;

        var fizzDict = new Dictionary<string, int[]>()
        {
            { "Fizz", new int[] { 31, 1 } },
            { "Buzz", new int[] { 59, 1 } },
            { "Bazz", new int[] { 127, 1 } },
            { "Bezz", new int[] { 19, 1 } },
            { "Bizz", new int[] { 91, 1 } },
        };
        stopwatch.Start();
        while (iteration <= maxIterations)
        {
            var result = "";

            foreach (var divisor in fizzDict)
            {
                if (divisor.Value[1] == divisor.Value[0])
                {
                    result += divisor.Key;
                    divisor.Value[1] = 1;
                    continue;
                }

                divisor.Value[1]++;
            }

            if (result == "")
            {
                result = iteration.ToString();
            }

            // Console.WriteLine(result);

            iteration++;
        }

        stopwatch.Stop();
        Console.WriteLine(stopwatch.ElapsedMilliseconds);
        return stopwatch.ElapsedMilliseconds;
    }
}