using static System.Console;

class IntegerRightTriangles
{
    static void Main()
    {
        int MaxSolutions = 0;
        int MaxPerimeter = 3;
        for (int Perimeter = 3; Perimeter <= 1000; Perimeter++)
        {
            int CurrSolutions = GetIntegerRightTriangle(Perimeter);
            if (CurrSolutions > MaxSolutions)
            {
                MaxSolutions = CurrSolutions;
                MaxPerimeter = Perimeter;
                WriteLine("Triangle with perimeter = {0}, has {1} solutions", Perimeter, CurrSolutions);
            }
        }
        Write(MaxPerimeter); Read();
    }

    // returns the number of possible right triangles with perimeter Perimeter
    static int GetIntegerRightTriangle(int Perimeter)
    {
        int SolutionsFound = 0;
        for (int a = 1; a <= Perimeter / 2; a++) // the other half is checked by b
        {
            for (int b = a; b <= Perimeter - a - 1; b++) // minus side a, minus one for side c
            {
                int c = Perimeter - a - b;
                if (c * c == a * a + b * b)
                {
                    WriteLine("Tri {0} is solved with a={1}, b={2}, c={3}", Perimeter, a, b, c);
                    SolutionsFound++;
                }
            }
        }
        return SolutionsFound;
    }
}