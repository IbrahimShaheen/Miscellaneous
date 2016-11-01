using System.IO;
using static System.Console;
using static System.StringSplitOptions;

class CodedTriangleNumbers
{
    static void Main()
    {
        TriangleNumberWordTester WordTester = new TriangleNumberWordTester();
        string Path = "p042_words.txt";
        string[] Words = File.ReadAllText(Path).Split(new char[] { ',', '"' }, RemoveEmptyEntries);

        int TriangleNumberWords = 0;
        foreach (string Word in Words)
        {
            if (WordTester.IsTriangleNumberWord(Word))
            {
                WriteLine("{0} is a good", Word);
                TriangleNumberWords++;
            }
        }
        WriteLine(TriangleNumberWords);
        Write("Done"); Read();
    }
}