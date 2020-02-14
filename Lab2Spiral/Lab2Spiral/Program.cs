using System;
using System.Collections.Generic;

namespace Lab2Spiral
{
    class Program {
        private static sbyte size;
        public static void prettyMatrixOutput(sbyte[,] a, sbyte size) {
            for (int i = 0; i < size; i++) {
                Console.Write("\t");
                for (int j = 0; j < size; j++) {
                    Console.Write("{0,4}", a[i,j] + "  ");
                }
                Console.Write("\n");
            }
        }
        
        static void Main(string[] args) {
            
            Console.WriteLine("> Enter matrix SIZE ...");
            string sizeString = Console.ReadLine();

            try {
                sbyte size = SByte.Parse(sizeString);
            }
            catch (FormatException) {
                Console.WriteLine("!You entered a wrong size number!");
                size = 3;
            }
            catch (Exception e) {
                Console.WriteLine(e);
                throw;
            }
            

            sbyte 
                counter = 0,
                i = 0,
                j = - 1,
                cellsToGo = size,
                node = 1, 
                dir = 1,
                total = 1;
            
            sbyte[,] a = new sbyte[size,size];

            while (total<=size*size) {
                for (; counter < cellsToGo; counter++) {
                    j += dir;
                    a[i,j] = node++;
                    total++;
                }
                counter = 0;
                cellsToGo--;
                

                for (; counter < cellsToGo; counter++) {
                    i += dir;
                    a[i,j] = node++;
                    total++;
                }

                counter = 0;
                dir *= -1;

            }

            prettyMatrixOutput(a, size);
            
        }
    }
}