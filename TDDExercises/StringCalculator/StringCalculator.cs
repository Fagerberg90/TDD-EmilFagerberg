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
            if (string.IsNullOrEmpty(numbers))
            {
                return 0;
            }

            var numberStringArray = numbers.Replace('\n', ',').Split(',');

            GetNumberArrayDefaultDelimeter(ref numberStringArray);

            var numberArray = numberStringArray.Select(int.Parse).ToArray();

          ValidateNonNegatives(numberArray);

            return numberArray.Where(x => x <= 1000).Sum(x => x);

        }

        private static void ValidateNonNegatives(int[] numberArray)
        {
            if (numberArray.Any(x => (x) < 0))
                throw new Exception($"negatives not allowed {string.Join(" ", numberArray.Where(x => (x) < 0))}");
        }


        private static void GetNumberArrayDefaultDelimeter(ref string[] numberArray)
        {

            if (!numberArray[0].StartsWith("//"))

                return;

            var delimeter = Convert.ToChar(numberArray[0].Remove(0, 2));

            numberArray = numberArray[1].Split(delimeter);
        }
    }
}

