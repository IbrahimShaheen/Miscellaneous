using static System.Math;

class QuadraticFxn
{
    public int A { get; }
    public int B { get; }
    public int Score { get; set; } // The number of consecutive primes produced by the fxn

    public QuadraticFxn(int A, int B)
    {
        this.A = A;
        this.B = B;
    }

    public int GetPrime(int N)
    {
        return (int)Pow(N, 2) + A * N + B;
    }

    public override string ToString()
    {
        return A + ", " + B + " : " + Score;
    }
}