using System;
using System.Text;

namespace Ejercicio1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 100, 200, 300,400, 500, 600, 700, 800, 900, 1000 };
            string result = ConcatenaValores(numbers);

            Console.WriteLine("Hello World!");
            Console.WriteLine(result);
        }


        private static string ConcatenaValores(int[] resultNumbers) {
            StringBuilder sb = new StringBuilder();
            int intTotal = resultNumbers.Length;
            string strResult = string.Empty;

            for (int x=0; x< intTotal; x++) {
                sb.Append(resultNumbers[x].ToString())
                    .Append(x < intTotal ? "," : string.Empty);

            }

            return sb.ToString();
        } 



    }
}
