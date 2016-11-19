using System;
using System.Linq;
using static System.String;
using static System.IO.File;
using static System.Console;

class Solution
{
    const int ASCII_a_VALUE = 97;
    const int ASCII_z_VALUE = 122;

    static void Main()
    {
        int[] EncryptedBytes = Array.ConvertAll(ReadAllText("p059_cipher.txt").Split(','), x => int.Parse(x));

        for (int i = ASCII_a_VALUE; i <= ASCII_z_VALUE; i++)
        {
            for (int j = ASCII_a_VALUE; j <= ASCII_z_VALUE; j++)
            {
                for (int k = ASCII_a_VALUE; k <= ASCII_z_VALUE; k++)
                {
                    int[] Password = { i, j, k };
                    int[] DecryptedBytes = new int[EncryptedBytes.Length];
                    for (int l = 0; l < EncryptedBytes.Length / 3; l++)
                    {
                        DecryptedBytes[3 * l] = EncryptedBytes[3 * l] ^ Password[0];
                        DecryptedBytes[3 * l + 1] = EncryptedBytes[3 * l + 1] ^ Password[1];
                        DecryptedBytes[3 * l + 2] = EncryptedBytes[3 * l + 2] ^ Password[2];
                    }
                    for (int l = 0; l < EncryptedBytes.Length % 3; l++)
                    {
                        DecryptedBytes[EncryptedBytes.Length / 3 * 3 + l] = EncryptedBytes[EncryptedBytes.Length / 3 * 3 + l] ^ Password[l];
                    }
                    if (IsDecrypted(DecryptedBytes))
                    {
                        WriteLine(Join("", DecryptedBytes.Select(x => "" + (char)x).ToArray()));
                        WriteLine(DecryptedBytes.Sum());
                    }
                }
            }
        }
        WriteLine("Press enter to exit...");
        Read();
    }

    // Returns true if DecryptedBytes contains the words "the", "be", and "to" represented in ASCII
    // These words are represented by {116, 104, 101} , {98, 101}, and {116, 111} respectively
    static bool IsDecrypted(int[] DecryptedBytes)
    {
        bool Contains_the = false, Contains_to = false, Contains_be = false;
        for (int i = 0; i < DecryptedBytes.Length - 2; i++)
        {
            int DecryptedByte = DecryptedBytes[i];
            switch (DecryptedByte)
            {
                case 116: // starts with "t"
                    if (DecryptedBytes[i + 1] == 104 && DecryptedBytes[i + 2] == 101)
                    {
                        Contains_the = true;
                    }
                    if (DecryptedBytes[i + 1] == 111)
                    {
                        Contains_to = true;
                    }
                    break;
                case 98: // starts with "b"
                    if (DecryptedBytes[i + 1] == 101)
                    {
                        Contains_be = true;
                    }
                    break;
            }
        }
        return Contains_the && Contains_to && Contains_be;
    }
}