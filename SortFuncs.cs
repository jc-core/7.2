namespace Assignment7_2 {
    internal class SortFuncs {
        public static bool IsAnagram(string first, string second) {

            Dictionary<char, int> counts = new();

            foreach (char letter in first) {
                if (counts.ContainsKey(letter))
                    counts[letter]++;
                else
                    counts[letter] = 1;
            }

            foreach (char letter in second) {

                if (!counts.ContainsKey(letter) || counts[letter] == 0)
                    return false;

                counts[letter]--;

            }

            return true;

        }
        public static string StandardSort(string word) {

            char[] letters = word.ToCharArray();
            Array.Sort(letters);

            return new string(letters);

        }

        public static string BubbleSort(string word) {

            char[] letters = word.ToCharArray();
            int end = letters.Length - 1;
            bool swapped = true;

            while (swapped) {

                swapped = false;

                for (int spot = 0; spot < end; spot++) {

                    if (letters[spot] > letters[spot + 1]) {

                        char hold = letters[spot];
                        letters[spot] = letters[spot + 1];
                        letters[spot + 1] = hold;

                        swapped = true;

                    }
                }

                end--;

            }

            return new string(letters);

        }

        public static string MergeSort(string word) {

            return new string(SortHalves(word.ToCharArray()));

        }

        static char[] SortHalves(char[] letters) {

            if (letters.Length <= 1)
                return letters;

            int middle = letters.Length / 2;

            char[] left = SortHalves(letters[..middle]);
            char[] right = SortHalves(letters[middle..]);

            return Merge(left, right);

        }

        static char[] Merge(char[] left, char[] right) {

            char[] merged = new char[left.Length + right.Length];

            int leftSpot = 0;
            int rightSpot = 0;
            int mergedSpot = 0;

            while (leftSpot < left.Length && rightSpot < right.Length) {
                if (left[leftSpot] <= right[rightSpot])
                    merged[mergedSpot++] = left[leftSpot++];
                else
                    merged[mergedSpot++] = right[rightSpot++];
            }

            while (leftSpot < left.Length)
                merged[mergedSpot++] = left[leftSpot++];

            while (rightSpot < right.Length)
                merged[mergedSpot++] = right[rightSpot++];

            return merged;

        }

        public static int[] MergeSort(int[] numbers) {

            return SortHalves(numbers);

        }

        static int[] SortHalves(int[] numbers) {

            if (numbers.Length <= 1)
                return numbers;

            int middle = numbers.Length / 2;

            int[] left = SortHalves(numbers[..middle]);
            int[] right = SortHalves(numbers[middle..]);

            return Merge(left, right);

        }

        static int[] Merge(int[] left, int[] right) {

            int[] merged = new int[left.Length + right.Length];

            int leftSpot = 0;
            int rightSpot = 0;
            int mergedSpot = 0;

            while (leftSpot < left.Length && rightSpot < right.Length) {
                if (left[leftSpot] <= right[rightSpot])
                    merged[mergedSpot++] = left[leftSpot++];
                else
                    merged[mergedSpot++] = right[rightSpot++];
            }

            while (leftSpot < left.Length)
                merged[mergedSpot++] = left[leftSpot++];

            while (rightSpot < right.Length)
                merged[mergedSpot++] = right[rightSpot++];

            return merged;

        }

        public static string ReverseVowels(string text) {

            char[] letters = text.ToCharArray();
            int left = 0;
            int right = letters.Length - 1;

            while (left < right) {

                if (!IsVowel(letters[left]))
                    left++;
                else if (!IsVowel(letters[right]))
                    right--;
                else {

                    char hold = letters[left];
                    letters[left] = letters[right];
                    letters[right] = hold;

                    left++;
                    right--;

                }
            }

            return new string(letters);

        }

        static bool IsVowel(char letter) {

            return "aeiouAEIOU".Contains(letter);

        }

        internal static bool QuickStop(string first, string second) {

            if (first == "" || second == "") {
                Console.WriteLine("No input, try again.");
                return true;
            }

            if (first.Length != second.Length) {

                Console.WriteLine("Different lengths, not an anagram.");
                return true;

            }

            else if (first == second) {
                Console.WriteLine("Same word, not an anagram.");
                return true;
            }

            return false;

        }
    }
}
