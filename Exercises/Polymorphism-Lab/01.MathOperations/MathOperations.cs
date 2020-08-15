using System;
using System.Collections.Generic;
using System.Text;

namespace Operations
{
    public class MathOperations
    {
        public int Add(int intNumbersA, int intNumbersB)
        {
            return intNumbersA + intNumbersB;
        }
        public double Add(double doubleNumbersA, double doubleNumbersB, double doubleNumbersC)
        {
            return doubleNumbersA + doubleNumbersB + doubleNumbersC;
        }
        public decimal Add(decimal decimalNumbersA, decimal decimalNumbersB, decimal decimalNumbersC)
        {
            return decimalNumbersA + decimalNumbersB + decimalNumbersC;
        }
    }
}
