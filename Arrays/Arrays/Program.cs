using System;

namespace Arrays {
    class Program {
        private static int arraySize;
        private static string[] stringArray;
        private static string substringToFind;
        
        static void Main(string[] args) {


            bool sizeNotEnetered = true;

            while (sizeNotEnetered) {
                Console.WriteLine("Enter array size ...");
                var arraySizeString = Console.ReadLine();

                try {
                    arraySize = int.Parse(arraySizeString);
                    sizeNotEnetered = false;
                }
                catch (Exception e) {
                    Console.WriteLine("Enter a number!!");
                }
            }
            
            // Array Initializing
            stringArray = new string[arraySize];
            
            for (var i = 0; i < arraySize; i++) {
                Console.WriteLine("Eneter a line ...");
                stringArray[i] = Console.ReadLine();
            }
            
            // Substring to find Initialiaing
            Console.WriteLine("Eneter the desired substring ...");
            substringToFind = Console.ReadLine();
            
            // Array search
            var occurenceCounter = 0;
            foreach (var line in stringArray) {
                if (line.IndexOf(substringToFind) != -1) {
                    occurenceCounter++;
                    Console.WriteLine("Match!");
                    Console.WriteLine("Here is the string : " + line);
                }
            }

            Console.WriteLine(occurenceCounter + " lines found!");

        }
    }
}