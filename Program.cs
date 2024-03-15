using System;
using System.Text;

namespace StringManipulation
{
    public class CharacterManipulator
    {
        private string input;

        public string Input
        {
            get { return input; }
            set
            {
                if (value != null)
                {
                    input = value;
                }
                else
                {
                    throw new ArgumentNullException(nameof(value), "Input não pode ser null");
                }
            }
        }

        public char[] SplitString()
        {
            if (input == null)
            {
                throw new InvalidOperationException("Input não foi inicializado.");
            }

            return input.ToCharArray();
        }

        public string JoinString(char[] characters)
        {
            if (characters == null)
            {
                throw new ArgumentNullException(nameof(characters), "Cos caracteres não podem ser nulos.");
            }

            return new string(characters);
        }
    }

    public class SubstringManipulator
    {
        private string input;

        public string Input
        {
            get { return input; }
            set
            {
                if (value != null)
                {
                    input = value;
                }
                else
                {
                    throw new ArgumentNullException(nameof(value), "Input não pode ser nulo.");
                }
            }
        }

        public string GetSubstring(int startIndex, int length)
        {
            if (input == null)
            {
                throw new InvalidOperationException("Input não foi inicializado.");
            }

            if (startIndex < 0 || length < 0 || startIndex + length > input.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex), "Índice inicial fora de escopo.");
            }

            return input.Substring(startIndex, length);
        }
    }

    public class ComparisonManipulator
    {
        public int CompareStrings(string first, string second)
        {
            if (first == null)
            {
                throw new ArgumentNullException(nameof(first), "primeira string não pode ser null.");
            }

            if (second == null)
            {
                throw new ArgumentNullException(nameof(second), "segunda string não pode ser null.");
            }

            return string.Compare(first, second);
        }

        public bool SearchForSubstring(string input, string searchString)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input), "Input não pode ser null.");
            }

            if (searchString == null)
            {
                throw new ArgumentNullException(nameof(searchString), "string de busca não pode ser null.");
            }

            return input.Contains(searchString);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            CharacterManipulator characterManipulator = new CharacterManipulator();
            characterManipulator.Input = "Hello, World!";
            char[] characters = characterManipulator.SplitString();
            string joinedString = characterManipulator.JoinString(characters);

            SubstringManipulator substringManipulation = new SubstringManipulator();
            substringManipulation.Input = "Hello, World!";
            string substring = substringManipulation.GetSubstring(0, 5);

            ComparisonManipulator comparisonManipulator = new ComparisonManipulator();
            int comparisonResult = comparisonManipulator.CompareStrings("Hello", "World");
            bool searchResult = comparisonManipulator.SearchForSubstring("Hello, World!", "World");

            Console.WriteLine("String Original: " + characterManipulator.Input);
            Console.WriteLine("Array: " + string.Join("", characters));
            Console.WriteLine("String Combinada: " + joinedString);
            Console.WriteLine("Substring: " + substring);
            Console.WriteLine("Resultado da comparação: " + comparisonResult);
            Console.WriteLine("Resultado da busca: " + searchResult);
        }
    }
}