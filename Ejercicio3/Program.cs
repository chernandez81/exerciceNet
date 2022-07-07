using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Ejercicio3
{
    class Program
    {
        enum enumPattern {
            CharacterValid,
            FileName,
            DateValid,
            FileBeginFact,
            FileValid,
            DateString
        }

        static void Main(string[] args)
        {
            int[] numbers = { 3, 5, 100, 1,  5, 8,4,3,2, 1,1,5,2,2,6,7};
            //OrderNumbers(numbers);
            //int[] intResult = OrderArrayV2(numbers, true); // OrderArray(numbers);
            ////int[] intResult = OrderArray(numbers);

            //for (int i = 0; i < intResult.Length; i++)
            //{
            //    Console.WriteLine(intResult[i]);
            //}

            //int res = Century(1717);
            //Console.WriteLine(res.ToString());

            //string value = "123454321";
            //Console.WriteLine(Palindrome(value.ToLower()));

            //var result =  Parse("23");
            //Console.WriteLine(result);

            //ObtienePesos();
            Console.WriteLine("Ingresa un numero arabigo por favor");
            int num = Convert.ToInt32( Console.ReadLine());

            //var result = ArabToroman(num);
            //Console.WriteLine($"Numero Arabigo {num} - su equivalente en numero Romano es {result}");

            //string num = "MCMLXXIX";
            //var result = RomanToArab(num);
            //Console.WriteLine($"Numero Romano {num} - su equivalente en numero Arabigo es {result}");

            //NumeroMayorRepetido(numbers);
            //Histograma(numbers);
            //SumaNumerosMasbajos();

            //string filename = "FILE_FACT0001_20220416.DAT"; // @"Comission_16/04/2022"; //;
            //Console.WriteLine(filename);
            //RegularExpressions(filename);
            Console.ReadKey();
        }

        private static int[] OrderArray(int[] numbers)
        {
            int intTotal = numbers.Length;
            // 3, 5, 1, 10, 9, 4, 1, 8,2,7,6

            List<int> values = numbers.ToList();
            List<int> lstResult = new List<int>();
            int intResult = 0;

            for (int i = 0; i < intTotal; i++)
            {
                if (intResult != 0)
                {                    
                    int index = Array.IndexOf(numbers, intResult);
                    values.Remove(numbers[index]);   
                }

                intResult = ObtenerNumeroMenor(values.ToArray());
                //intResult = ObtenerNumeroMayor(values.ToArray());

                //if(!lstResult.Contains(intResult)) 
                lstResult.Add(intResult);
            }

            return lstResult.ToArray();
        }

        private static int ObtenerNumeroMenor(int[] numbers) {
            int intTotal = numbers.Length;
            List<int> lstNumerosMenores = new List<int>();
            int intValue = 0;

            for (int i = 0; i < intTotal; i++) {
                intValue = numbers[0];
                if (intValue > numbers[i]) lstNumerosMenores.Add(numbers[i]);
            }

            for (int j = 0; j < lstNumerosMenores.Count; j++)
            {
                if (intValue > lstNumerosMenores[j]) intValue = lstNumerosMenores[j];
            }

            return intValue;
        }

        private static int ObtenerNumeroMayor(int[] numbers)
        {
            int intTotal = numbers.Length;
            List<int> lstNumerosMenores = new List<int>();
            int intValue = 0;

            for (int i = 0; i < intTotal; i++)
            {
                intValue = numbers[0];
                if (intValue < numbers[i]) lstNumerosMenores.Add(numbers[i]);
            }

            for (int j = 0; j < lstNumerosMenores.Count; j++)
            {
                if (intValue < lstNumerosMenores[j]) intValue = lstNumerosMenores[j];
            }

            return intValue;
        }

        private static int[] OrderArrayV2(int[] numbers, bool ascending = true)
        {
            int total = numbers.Length, i = 0;
            int[] resultNumbers = numbers;
            List<int> lstNumbers = numbers.ToList();

            while (i < total)
            {
                //Gets the positions of the next available spot to orderascendent or descendent
                int position = ascending ? total - (i + 1) : i;

                //Find the gratest number given an array of numbers
                int greaterNumber = GetGreatesNumber(lstNumbers.ToArray());

                //Remove the recently found greates number  from the list
                lstNumbers.RemoveAt(lstNumbers.IndexOf(greaterNumber));

                //Sets the recently found greates number in the correct positions
                resultNumbers[position] = greaterNumber;
                i++;
            }

            return resultNumbers;
        }

        private static int GetGreatesNumber(int[] numbers)
        {
            int greatestNumber = numbers[0];

            for(int i=1; i< numbers.Length; i++)
            {
                if (greatestNumber < numbers[i]) greatestNumber = numbers[i];
            }

            return greatestNumber;
        }

        private static void OrderNumbers(int[] numbers) {
            int I = 0;
            int K = 0;
            int CAN = 0;
            int AUX = 0;
            string linea;
            Console.Write("CUANTOS ELEMENTOS MÁX=12:");
            linea = Console.ReadLine();
            CAN = int.Parse(linea);
            int[] VEC = new int[CAN + 1];
            // INGRESO
            for (I = 1; I <= CAN; I++)
            {
                Console.Write("POSICIÓN {0} ==>", I);
                linea = Console.ReadLine();
                VEC[I] = int.Parse(linea);
            }
            // PROCESO
            for (I = 1; I <= CAN - 1; I++)
            {
                for (K = I + 1; K <= CAN; K++)
                {
                    if ((VEC[I] < VEC[K]))
                    {                       
                        AUX = VEC[K];
                        VEC[K] = VEC[I];
                        VEC[I] = AUX;
                    }
                }
            }
            Console.WriteLine();
            // SALIDA
            Console.WriteLine("ARREGLO ORDENADO DESCENDENTE");
            for (I = 1; I <= CAN; I++)
            {
                Console.WriteLine(VEC[I]);
            }
            Console.Write("Pulse una Tecla:");
            Console.ReadLine();
        }

        private static int Century(int year)
        {
            return --year / 100 + 1;
        }

        private static bool Palindrome(string input)
        {
            //return input.ToLower().SequenceEqual(input.ToLowerInvariant().Reverse());
            string firstHalf = input.Substring(0, input.Length / 2);
            char[] arr = input.ToCharArray();

            Array.Reverse(arr);

            string temp = new string(arr);
            string secondHalf = temp.Substring(0, temp.Length / 2);

            return firstHalf.Equals(secondHalf);
        }

        private static readonly Dictionary<char, int> Map = new Dictionary<char, int>()
        {
            { 'I',1 },
            { 'V',5 },
            { 'X',10 },
            { 'L',50 },
            { 'C',100 },
            { 'D',500 },
            { 'M',1000 }
        };

        private static int Parse(string roman)
        {
            int result = 0;
            for(int i=0; i<roman.Length; i++)
            {
                if (i + 1 < roman.Length && IsSubtractive(roman[i], roman[i + 1]))
                { result -= Map[roman[i]]; }
                else { result += Map[roman[i]]; }
            }

            return result;
        }

        private static bool IsSubtractive(char c1, char c2)
        {
            return Map[c1] < Map[c2];
        }

        private static string ArabToroman(int num)
        {
            string[] rUni = new string[] { "", "I","II","III","IV", "V","VI","VII","VIII","IX"};
            string[] rDec = new string[] { "", "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC" };
            string[] rCen = new string[] { "", "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM" };
            string[] rMil = new string[] { "", "M", "MM", "MMM", "I̅V̅", "V̅", "V̅I̅", "V̅I̅I̅", "V̅I̅I̅I̅", "I̅X̅" };

            int unidades = num % 10;
            int decenas = (num/10) % 10;
            int centenas = (num / 100) % 10;
            int miles = (num / 1000) % 10;

            return rMil[miles] + rCen[centenas] + rDec[decenas] + rUni[unidades];
        }

        private static int RomanToArab(string num)
        {
            string[] rUni = new string[] { "", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX" };
            string[] rDec = new string[] { "", "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC" };
            string[] rCen = new string[] { "", "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM" };
            string[] rMil = new string[] { "", "M", "MM", "MMM", "I̅V̅", "V̅", "V̅I̅", "V̅I̅I̅", "V̅I̅I̅I̅", "I̅X̅" };

            int miles = RomanNum(rMil,num);
            num = num.Substring(rMil[miles].Length);

            int centenas = RomanNum(rCen, num);
            num = num.Substring(rCen[centenas].Length);

            int decenas = RomanNum(rDec, num);
            num = num.Substring(rDec[decenas].Length);

            int unidades = RomanNum(rUni, num);
            num = num.Substring(rUni[unidades].Length);
            //3345
            //MMMCCCXCV

            if (num != "") return -1;

            return (miles * 1000) + (centenas * 100) + (decenas * 10) + unidades;
        }

        private static int RomanNum(string[] strRomans, string roman)
        {
            for(int i=strRomans.Length-1; i>=0; i--)
            {
                if (strRomans[i] != "" && roman.StartsWith(strRomans[i])) return i;
            }

            return 0;
        } 

        private static void NumeroMayorRepetido(int[] numbers)
        {           
            int tamanio = numbers.Length;

            Dictionary<int, int> dictionaryNumbers = new Dictionary<int, int>();

            int total;
            for (int i = 0; i < tamanio; i++)
            {
                total = 0;
                int value = Convert.ToInt32(numbers[i]);

                for (int j = 0; j < tamanio; j++)
                {
                    if (value == numbers[j]) total++;
                }

                if (dictionaryNumbers.Count == 0) dictionaryNumbers.Add(value, total);
                else
                {
                    try
                    {
                        var result = Convert.ToInt32(dictionaryNumbers[Convert.ToInt32(numbers[i])]);
                        continue;
                    }
                    catch (Exception)
                    {
                        dictionaryNumbers.Add(value, total);
                    }
                }
            }

            total = Convert.ToInt32(dictionaryNumbers[numbers[0]]);
            int index = numbers[0];

            foreach (var item in dictionaryNumbers)
            {
                if (total < item.Value)
                {
                    total = item.Value;
                    index = item.Key;
                }
            }

            Console.WriteLine($"longest : {total}");
            Console.WriteLine($"number : {index}");
        }

        private static void Histograma(int[] numbers)
        {
            int tamanio = numbers.Length;

            Dictionary<int, int> numerosdict = new Dictionary<int, int>();

            for (int i = 0; i < tamanio; i++)
            {
                int total = 0;
                int value = Convert.ToInt32(numbers[i]);

                for (int j = 0; j < tamanio; j++)
                {
                    if (value == numbers[j]) total++;
                }

                if (numerosdict.Count == 0) numerosdict.Add(value, total);
                else
                {
                    try
                    {
                        var result = Convert.ToInt32(numerosdict[Convert.ToInt32(numbers[i])]);

                        if (result <= 0) numerosdict.Add(value, total);
                    }
                    catch (Exception)
                    {
                        numerosdict.Add(value, total);
                    }

                }
            }

            var ordered = numerosdict.OrderBy(x => x.Key);

            int index = 1;
            foreach (var item in ordered)
            {
                StringBuilder sb = new StringBuilder();
                int totalNum = 0;

                totalNum = item.Value;

                for (int j = 0; j < totalNum; j++)
                {
                    sb.Append("*");
                }

                if (index == item.Key) Console.WriteLine($"{(item.Key)} : {sb.ToString()}");
                else
                {
                    for(int l=index; l<=item.Key; l++)
                    {
                        if (l < item.Key)
                        {
                            Console.WriteLine($"{index} : ");
                            index++;
                        }
                        else Console.WriteLine($"{(item.Key)} : {sb.ToString()}");
                    }
                }
                index++;
            }

        } 

        private static void SumaNumerosMasbajos()
        {
            int[] numerosdict = new int[3];
            int[] numbers = { 1,2,9,2,5,3,5,1,5 };
            int total = 0;
            int numeroTotal = 0;

            //129
            //253
            //515
            int[,] cubo = new int[3, 3] { 
                { 1, 2, 9 }, 
                { 2, 1, 3 }, 
                { 5, 1, 1 }
            };

            for(int i =0; i< 3; i++)
            {
                total = cubo[0, i];
                for (int j=0; j<3; j++)
                {
                    if(total> cubo[j, i])
                    {
                        total = cubo[j, i];
                        Console.WriteLine(total);
                    }
                    
                }

                numerosdict[i] = total;
            }

            StringBuilder sb = new StringBuilder();

            for(int i=0; i<numerosdict.Length; i++)
            {
                sb.Append(numerosdict[i] + " ");
            }

            Console.WriteLine(sb.ToString());
        }

        private static void ObtienePesos() {

            Console.WriteLine("Ingresa  el dinero a separar");
            int value = Convert.ToInt32( Console.ReadLine());

            int unidades = (value % 10);
            int decenas = (value / 10) % 10;
            int centenas = (value / 100) % 10;
            int miles = (value / 1000) % 10;
            int deceMiles = (value / 10000) % 10;

            Console.WriteLine($"El dinero ingresado es {value}");
            Console.WriteLine($"Son {((miles*1000) + (deceMiles*10000)) } billete(s) de $1000");
            Console.WriteLine($"Son {centenas } billete(s) de $100");
            Console.WriteLine($"Son {decenas } billete(s)/moneda(s) de $10");
            Console.WriteLine($"Son {unidades } monedas de $1");
        }
        private static void RegularExpressions(string strText) {
            //var pattern = @"[:\\*{}]";
            //var pattern = @"\d{6}.([mty]{3})";  //"345678_mty"
            //var pattern = @"\d{2}[(-|/)]\d{2}[(-|/)][(\d)]{4}";  //"01/01/22"
            //var pattern = @"FACT[\d]{4}.\d{8}.DAT"; //"FACT0001_20220416.DAT"
            //var pattern = @"\d{8}"; //20220416
            //var pattern = "[^f-z]{4}"; //FILE

            var pattern = ReturnPattern(enumPattern.CharacterValid);
            var matches = Regex.Match(strText, pattern);

            Console.WriteLine(matches.Value);
        }

        private static string ReturnPattern(enumPattern options) {
            string pattern = string.Empty;
            
            switch (options)
            {
                case enumPattern.CharacterValid:
                    pattern = @"[:\\*{}.]";
                    break;
                case enumPattern.DateString:
                    pattern = @"\d{8}";
                    break;
                case enumPattern.DateValid:
                    pattern = @"\d{2}[(-|/)]\d{2}[(-|/)][(\d)]{4}";
                    break;
                case enumPattern.FileBeginFact:
                    pattern = @"[^f-t]{4}[\d]{4}.\d{8}.DAT";
                    break;
                case enumPattern.FileName:
                    pattern = @"\d{6}.([mty]{3})";
                    break;
                case enumPattern.FileValid:
                    pattern = "[^f-z]{4}";
                    break;
            }


            return pattern;
        }
    }
}
