using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator
{
    public class StringCalculator
    {
        public static int Add(string numbers)
        {
            var delimiter = ',';


            if (string.IsNullOrEmpty(numbers))
            {
                return 0;
            }

            var numberStringArray = numbers.Replace('\n', delimiter).Split(delimiter);

            GetNumberArrayDefaultDelimeter(ref numberStringArray, delimiter);

            var numberArray = numberStringArray.Where(x => !string.IsNullOrEmpty(x)).Select(int.Parse).ToArray();

          ValidateNonNegatives(numberArray);

            return numberArray.Where(x => x <= 1000).Sum(x => x);

        }

        private static void ValidateNonNegatives(int[] numberArray)
        {
            if (numberArray.Any(x => (x) < 0))
                throw new Exception($"negatives not allowed {string.Join(" ", numberArray.Where(x => (x) < 0))}");
        }


        private static void GetNumberArrayDefaultDelimeter(ref string[] numberArray, char delimiter)
        {

            if (!numberArray[0].StartsWith("//"))

                return;

            var customDelimeters = numberArray[0].Remove(0, 2).Distinct();

            foreach (var customDelimeter in customDelimeters)
            {
            numberArray[1] =numberArray[1].Replace(customDelimeter,delimiter);

            }


            numberArray = numberArray[1].Split(delimiter);
        }
    }
}

