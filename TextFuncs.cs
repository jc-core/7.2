namespace Assignment7_2 {
    internal class TextFuncs {

        public static string Normalize(string text) {

            return string.Concat(text.ToLowerInvariant().Where(character => !char.IsWhiteSpace(character)));

        }

        internal static string ReadChoice(string prompt) {

            while (true) {

                Console.Write($"{prompt} ");
                string? choice = Console.ReadLine();

                if (choice == null)
                    return "";

                choice = choice.Trim();

                if (choice == "1" || choice == "2" || choice == "3")
                    return choice;

                Console.WriteLine("1, 2 or 3 only, try again.");

            }
        }

        internal static int[] ReadNumbers(string prompt) {

            while (true) {

                Console.Write($"{prompt} ");
                string? line = Console.ReadLine();

                if (line == null)
                    return new int[0];

                string[] pieces = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (pieces.Length == 0) {
                    Console.WriteLine("Can't be blank, try again.");
                    continue;
                }

                int[] numbers = new int[pieces.Length];
                bool parsed = true;

                for (int spot = 0; spot < pieces.Length; spot++) {
                    if (!int.TryParse(pieces[spot], out int value)) {
                        parsed = false;
                        break;
                    }
                    numbers[spot] = value;
                }

                if (parsed)
                    return numbers;

                Console.WriteLine("Whole numbers only, separated by spaces, try again.");

            }
        }

        internal static string ReadText(string prompt) {

            while (true) {

                Console.Write($"{prompt} ");
                string? text = Console.ReadLine();

                if (text == null)
                    return "";

                if (text.Trim() == "")
                    Console.WriteLine("Can't be blank, try again.");
                else if (!text.All(character => char.IsLetter(character) || char.IsWhiteSpace(character)))
                    Console.WriteLine("Letters and spaces only, try again.");
                else
                    return text;

            }

        }

        internal static void ShowResult(string label, bool isAnagram) {

            Console.WriteLine($"{label} {(isAnagram ? "True" : "False")}");

        }
    }
}
