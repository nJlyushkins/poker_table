using System;

public class Solution
{
    public int MinMovesToEqualize(int[] chips)
    {
        int total = 0;
        foreach (int chip in chips)
        {
            total += chip;
        }
        int n = chips.Length;
        int target = total / n;
        int[] diffs = new int[n];
        for (int i = 0; i < n; i++)
        {
            diffs[i] = chips[i] - target;
        }

        int minMoves = int.MaxValue;
        for (int start = 0; start < n; start++)
        {
            int currentSum = 0;
            int totalMoves = 0;
            for (int k = 0; k < n; k++)
            {
                int idx = (start + k) % n;
                currentSum += diffs[idx];
                totalMoves += Math.Abs(currentSum);
            }
            minMoves = Math.Min(minMoves, totalMoves);
        }
        return minMoves;
    }
}

class Program
{
    static void Main(string[] args)
    {
        var startTime = System.Diagnostics.Stopwatch.StartNew();
        Solution solution = new Solution();
        int[][] chipTest = {
            new int[]{1,5,9,10,5},
            new int[]{1,2,3},
            new int[]{0, 1, 1, 1, 1, 1, 1, 1, 1, 2}
        };
        int[] expectedAnswer = { 12, 1, 1 };
        for (int i = 0; i < 3; i++)
        {
            int[] currentTest = (int[])chipTest[i].Clone();
            int res = solution.MinMovesToEqualize(currentTest);
            if (res == expectedAnswer[i])
            {
                Console.WriteLine($"Test #{i} passed!");
            }
            else
            {
                Console.WriteLine($"Test #{i} failed. Expected {expectedAnswer[i]}, got {res}.");
            }
        }
        startTime.Stop();
        var resultTime = startTime.Elapsed;
        string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:000}",
            resultTime.Hours,
            resultTime.Minutes,
            resultTime.Seconds,
            resultTime.Milliseconds);
        Console.WriteLine("Total time elapsed: {0}", elapsedTime);
    }
}