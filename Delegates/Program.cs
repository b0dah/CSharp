using System;

namespace Delegates {
    class Program {

        static int firstMethod(int a) {
            return a;
        }

        static int secondMethod(int a) {
            return a * 2;
        }

        delegate int SingleParamDelegate(int param); // Delegate Type

        delegate void SingleParameterMultiAdressDelegate(int param);
        
        static void methodWhichAcceptsAnother(SingleParamDelegate parameterFunction, int parameterValue) {
            int result = parameterFunction(parameterValue);
            Console.WriteLine("Parameter value is {0}, result is {1}", parameterValue, result);
        }

        static void methodWhichAcceptsSequnceOfMethods(SingleParameterMultiAdressDelegate funcParameter, int valParamaeter) {
            Console.WriteLine("\n********\n");
            funcParameter(valParamaeter);
        }

        static void Main(string[] args) {
            SingleParamDelegate[] deledateInstances = new[] {
                new SingleParamDelegate(firstMethod),
                new SingleParamDelegate(secondMethod)
            };

            foreach (var instance in deledateInstances) {
                methodWhichAcceptsAnother(instance, 1);
            }
            
            // EXAMPLE 2 MULTIADRESS DELEGATES
            Console.WriteLine("MultiAdress Delegates: ");
            
            SingleParameterMultiAdressDelegate callsSequence = new SingleParameterMultiAdressDelegate(MultiAdressDelegatesDemo.multiplyByTwo);
            callsSequence += MultiAdressDelegatesDemo.square;
            
            methodWhichAcceptsSequnceOfMethods(callsSequence, 1);
            methodWhichAcceptsSequnceOfMethods(callsSequence, 2);
            methodWhichAcceptsSequnceOfMethods(callsSequence, 3);

        }
    }
}