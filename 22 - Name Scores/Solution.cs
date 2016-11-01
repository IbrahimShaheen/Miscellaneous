using System;
using System.IO;
using System.Collections.Generic;
using static System.Console;

class NameScores
{
    static String DataDir = "ProblemData.txt";
    static readonly int FirstCharVal = 97;

    static void Main()
    {
        int TotalScore = 0;
        List<String> Names = LoadAndSort();
        for (int i = 0; i < Names.Count; i++)
        {
            String Name = Names[i].ToLower();
            int NameScore = ScoreOf(Name);
            NameScore *= i + 1;
            TotalScore += NameScore;
        }
        WriteLine(TotalScore);
        Read();
    }

    // reads the file and loads and sorts the names
    static List<String> LoadAndSort()
    {
        List<String> Names = new List<String>();
        Names.Capacity = 5000;
        foreach (String Line in File.ReadAllLines(DataDir))
        {
            Names.Add(Line);
        }
        Names.Sort();
        return Names;
    }

    // returns the alphabetic score of Name
    static int ScoreOf(String Name)
    {
        int Score = 0;
        foreach (char Char in Name)
        {
            Score += Char + 1 - FirstCharVal;
        }
        return Score;
    }
}