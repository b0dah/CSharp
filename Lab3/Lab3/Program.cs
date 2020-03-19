using System;
using System.Collections.Generic;

namespace Lab3
{
    class TestClass
    {
        public int x, y, z;
        
        // Создание класса с различными конструкторами для примеров 1-4
        public TestClass()
        {
            x = 2;
            y = 3;
            z = 4;
        }

        public TestClass(int x)
        {
            this.x = x;
            this.y = x;
            this.z = x;
        }
        
        public TestClass(int x,int y,int z)
        {
            this.x=x;
            this.y=y;
            this.z=z;
        }

        private TestClass(int x,int y) : this(x)
        {
            this.y = y;
            this.z = 0;
        } 

        
    }

    class ClassWithReadOnlyProperty
    {
        public int x, y, z;
        public readonly int readOnlyProperty;

        public ClassWithReadOnlyProperty()
        {
            readOnlyProperty = 10;
        }
        
        // Модификация конструктора для задачи 3.
        public ClassWithReadOnlyProperty(int value)
        {
            this.readOnlyProperty = (value < 10 && value>0) ? value : 0;
        }

    }
    
    
    class Program
    {
        static void Main(string[] args)
        {
            TestClass instance = new TestClass();
            Console.WriteLine("x ={0,2}     y = {1,2}     z ={2,2}", instance.x, instance.y, instance.z);
            
            TestClass instance1 = new TestClass(1);
            Console.WriteLine("x ={0,2}     y = {1,2}     z ={2,2}", instance1.x, instance1.y, instance1.z);

            TestClass instance2 = new TestClass(1,23,44);
            Console.WriteLine("x ={0,2}     y = {1,2}     z ={2,2}", instance2.x, instance2.y, instance2.z);
            
            // ex3
            ClassWithReadOnlyProperty roInstance = new ClassWithReadOnlyProperty();
            // roInstance.readOnlyProperty = 10; // ERROR!
            
            // Создание объектов для задачи 2
            //10 objects
            List<ClassWithReadOnlyProperty> instances = new List<ClassWithReadOnlyProperty>();
            
            for (int i = 0; i < 15; i++) {
                ClassWithReadOnlyProperty currentInstance = new ClassWithReadOnlyProperty(i);
                Console.WriteLine("index = " + i + "     currrent instance field value is " + currentInstance.readOnlyProperty);
                instances.Add(currentInstance);
            }
            
        }
    }
}