using System;

namespace HomeTask4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int min = 0;
            int max = 26;

            int[] generatedNumbers = GenereteArray(min, max, size);
           
            int[] evenNumbers = SelectEven(generatedNumbers); 
            int[] oddNumbers = SelectOdd(generatedNumbers);

            char[] lettersFromEven = ConvertToLetters(evenNumbers);
            char[] lettersFromOdd = ConvertToLetters(oddNumbers);

            char[] lettersToUpper = new char[] {'a', 'e', 'i', 'd', 'h', 'j'};
            char[] lettersFromEvenCapital = ConvertToUpper(lettersFromEven, lettersToUpper);
            char[] lettersFromOddCapital = ConvertToUpper(lettersFromOdd, lettersToUpper);

            if (GetUpperCount(lettersFromEvenCapital) >= GetUpperCount(lettersFromOddCapital))
                Console.WriteLine(string.Join(" ",lettersFromEvenCapital));
            else Console.WriteLine(string.Join(" ",lettersFromOddCapital));

            Console.WriteLine("\n" + string.Join(" ", lettersFromEvenCapital));
            Console.WriteLine(string.Join(" ", lettersFromOddCapital));
        }

        static int GetUpperCount(char[] letters)
        {
            int count = 0;
            for (int i = 0; i < letters.Length; i++)
                if (char.IsUpper(letters[i]))
                    count++;
            return count;
        }

        private static char[] ConvertToUpper(char[] letters, char[] toUpper)
        {
            for (int i = 0; i < letters.Length; i++)
            {
                if(Contains(letters[i], toUpper)) 
                    letters[i] = char.ToUpper(letters[i]);
            }

            return letters;
        }

        static bool Contains(char letter, char[] letters)
        {
            for (int i = 0; i < letters.Length; i++)
            {
                if (letters[i] == letter)
                    return true;
            }

            return false;
        }

        private static char[] ConvertToLetters(int[] numbers)
        {
            char[] letters = new char[numbers.Length];
             
            for (int i = 0; i < numbers.Length; i++)
                letters[i] = Convert(numbers[i]);

            return letters;
            
            static char Convert(int alphabetIndex) =>
                (char)(96 + alphabetIndex);
        }

        static int [] GenereteArray(int min, int max, int size)
        {
            int[] array = new int[size];

            Random randNum = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = randNum.Next(min, max);
            }

            return array;
        }

        static int[] SelectEven(int[] array)
        {
            int size = 0;
            for (int i = 0; i < array.Length; i++)
                if (array[i] % 2 == 0)
                    size++;
            int[] evenArray = new int[size];

            int count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 == 0)
                {
                    evenArray[count] = array[i];
                    count++;
                }
            }

            return evenArray;
        }

        static int[] SelectOdd(int[] array)
        {
            int size = 0;
            for (int i = 0; i < array.Length; i++)
                if (array[i] % 2 != 0)
                    size++;
            int[] evenOdd = new int[size];

            int count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 != 0)
                {
                    evenOdd[count] = array[i];
                    count++;
                }
            }

            return evenOdd;
        }
       

    }
}
