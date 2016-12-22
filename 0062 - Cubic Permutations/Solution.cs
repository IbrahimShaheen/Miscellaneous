using System.Collections.Generic;
using static System.Console;
using static System.Math;

class P62
{
    const int PERMS_COUNT = 5;
    static void Main()
    {
        int Digits = 2;

        long CubeWithPermsCount = -1;
        while (CubeWithPermsCount == -1)
        {
            Dictionary<int[], NumPermsCount> Perms =
                new Dictionary<int[], NumPermsCount>(new ArrayEqualityComparer());
            int Min = (int)Ceiling(Pow(Pow(10, Digits - 1), 1.0 / 3));
            int Max = (int)Floor(Pow(Pow(10, Digits) - 1, 1.0 / 3));
            for (long i = Min; i <= Max; i++)
            {
                long CubicNum = i * i * i;
                int[] DigitsCounter = GetDigitsCounter(CubicNum);
                if (!Perms.ContainsKey(DigitsCounter))
                {
                    Perms.Add(DigitsCounter, new NumPermsCount(CubicNum));
                }
                NumPermsCount temp = Perms[DigitsCounter];
                temp.PermutationsFound++;
                Perms[DigitsCounter] = temp;
            }
            CubeWithPermsCount = HasCubeWithPermsCount(Perms);
            Digits++;
        }
        WriteLine("The smallest cube with {0} cubic permutations is {1}", PERMS_COUNT, CubeWithPermsCount);
        WriteLine("Press enter to exit...");
        Read();
    }

    // Returns the cube in Perms which has PERMS_COUNT permutations
    // Returns -1 if that cube doesn't exist
    static long HasCubeWithPermsCount(Dictionary<int[], NumPermsCount> Perms)
    {
        foreach (NumPermsCount NumPermsCount in Perms.Values)
        {
            if (NumPermsCount.PermutationsFound == PERMS_COUNT)
            {
                return NumPermsCount.Num;
            }
        }
        return -1;
    }

    // Returns an array of length 10 which contains the count of the digits 0 - 9 of Num
    static int[] GetDigitsCounter(long Num)
    {
        int[] Result = new int[10];
        while (Num != 0)
        {
            long Digit = Num % 10;
            Result[Digit]++;
            Num /= 10;
        }
        return Result;
    }

    struct NumPermsCount
    {
        public long Num;
        public int PermutationsFound;
        public NumPermsCount(long Num)
        {
            this.Num = Num;
            this.PermutationsFound = 0;
        }
    }
}

// What I think should be part of a framework somewhere...
// Thank you Glen Hughes for writing this on stack overflow
public class ArrayEqualityComparer : IEqualityComparer<int[]>
{
    public bool Equals(int[] x, int[] y)
    {
        if (x.Length != y.Length)
        {
            return false;
        }
        for (int i = 0; i < x.Length; i++)
        {
            if (x[i] != y[i])
            {
                return false;
            }
        }
        return true;
    }

    public int GetHashCode(int[] obj)
    {
        int result = 17;
        for (int i = 0; i < obj.Length; i++)
        {
            unchecked
            {
                result = result * 23 + obj[i];
            }
        }
        return result;
    }
}