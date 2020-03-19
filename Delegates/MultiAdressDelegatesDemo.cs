using System;

namespace Delegates {
    public class MultiAdressDelegatesDemo {
        public static void multiplyByTwo(int a) {
            var result = a * 2;
            Console.WriteLine("Parameter value is {0}, result is {1}", a, result);
        }

        public static void square(int a) {
            var result = a * a;
            Console.WriteLine("Parameter value is {0}, result is {1}", a, result);
        }
        
        
    }
}