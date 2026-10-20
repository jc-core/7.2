using static Assignment7_2.TextFuncs;
using static Assignment7_2.SortFuncs;
namespace Assignment7_2 {
    internal class Program {

        static void Main(string[] args) {

        startLoop:

            switch (ReadChoice("(1) Merge sort  (2) Flip vowels  (3) Anagram:")) {
                case "1":
                    RunMergeSort();
                    break;
                case "2":
                    RunReverseVowels();
                    break;
                case "3":
                    RunAnagram();
                    break;
                default:
                    Console.WriteLine("No input, try again.");
                    break;
            }

            Console.WriteLine();
            Console.WriteLine("...");
            Console.ReadKey(true);
            Console.Clear();

            goto startLoop;

        }

        static void RunMergeSort() {

            Console.WriteLine("Whole numbers, separated by spaces.");
            int[] numbers = ReadNumbers("Numbers:");

            if (numbers.Length == 0) {
                Console.WriteLine("No input, try again.");
                return;
            }

            Console.WriteLine($"Before: {string.Join(" ", numbers)}");
            Console.WriteLine($"After:  {string.Join(" ", MergeSort(numbers))}");

        }

        static void RunReverseVowels() {

            Console.WriteLine("Vowels swap end to end, letters and spaces only.");
            string text = ReadText("Word or phrase:");

            if (text == "") {
                Console.WriteLine("No input, try again.");
                return;
            }

            Console.WriteLine($"Before: {text}");
            Console.WriteLine($"After:  {ReverseVowels(text)}");

        }

        static void RunAnagram() {

            Console.WriteLine("Two words, letters and spaces only.");
            string first = Normalize(ReadText("First word:"));
            string second = Normalize(ReadText("Second word:"));

            if (!QuickStop(first, second)) {

                ShowResult("Merge sort:", MergeSort(first) == MergeSort(second));
                ShowResult("Bubble sort:", BubbleSort(first) == BubbleSort(second));
                ShowResult("Dictionary:", IsAnagram(first, second));
                ShowResult("Standard library:", StandardSort(first) == StandardSort(second));

            }

        }
    }
}
