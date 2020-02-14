using System;

namespace ConsoleApps
{
    class TestClass
    {
        private int field = 0;
        public int getterSetter
        {
            get { return field; }
            set { field = value; }
        }
    }
    
     class Program
    {
        
        
        
        static void Main(string[] args)
        {
            TestClass instance = new TestClass();
            Console.WriteLine("field = " + instance.getterSetter);
            instance.getterSetter = 50;
            Console.WriteLine("field = " + instance.getterSetter);

        }
    }
}