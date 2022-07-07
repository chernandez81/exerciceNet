using System;
using System.Collections.Generic;

namespace Ejercicio2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 2, 15, 30};
            int[] result = ReturnPairs(numbers);

            for (int i=0; i<result.Length; i++) {
                Console.WriteLine( $" Resultado encontrado: {result[i]}");
            }

        }

        private static int[] ReturnPairs(int[] numbers) {
            int intTotal = numbers.Length;
            List<int> lstNumbersPairs = new List<int>();

            for (int i=0; i <intTotal; i++) {
                int intValue = numbers[i];

                if (intValue % 2 == 0) lstNumbersPairs.Add(intValue);
            }

            return lstNumbersPairs.ToArray();
        }
    }
}
