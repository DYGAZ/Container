using System;
using System.Collections.Generic;
using Microsoft.Practices.Unity;

namespace IOC
{
    class Program
    {
        static void Main()
        {

            var container = new UnityContainer();
            container.RegisterType<ICalculator, Calculator>();

            var simpleCalculator = container.Resolve<ICalculator>();

            simpleCalculator.DisplayOperations();
            while (true)
            {
                try
                {
                    simpleCalculator.ChooseOperations();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Invalid Value: " + e.GetType() + " Thrown");
                    Console.WriteLine("Exiting...");
                    break;

                }
               
            }
            Console.Read();
        }
    }
    public interface ICalculator
    {
        void DisplayOperations();
        void ChooseOperations();
    }
    public class Calculator : ICalculator
    {
        readonly List<IOperation> _operations = new List<IOperation>();
        public Calculator(Subtraction sub, Addition add)
        {
            _operations.Add(sub);
            _operations.Add(add);
        }
        public void DisplayOperations()
        {
            Console.WriteLine("This Calculator has the following operations:");
            foreach (var op in _operations)
            {
                Console.WriteLine(op.GetName());
            }
        }
        public void ChooseOperations()
        {
            Console.WriteLine("Choose an Operation by number");
            for (var i = 0; i < _operations.Count; i++)
            {
                Console.Write(i + ": ");
                Console.WriteLine(_operations[i].GetName());
            }
            var input = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(_operations[input].DoSomething());
        }
    }
    public interface IOperation
    {
        string GetName();
        void GetValues();
        int DoSomething();
    }
    public class Addition : IOperation
    {
        int _val1, _val2;

        public string GetName()
        {
            return "Addition";
        }
        public void GetValues()
        {
            Console.Write("Input Values: ");
            _val1 = Convert.ToInt32(Console.ReadLine());
            _val2 = Convert.ToInt32(Console.ReadLine());
        }
        public int DoSomething()
        {
            GetValues();
            return _val1 + _val2;
        }
    }
    public class Subtraction : IOperation
    {
        int _val1, _val2;

        public string GetName()
        {
            return "Subtration";
        }

        public void GetValues()
        {
            Console.Write("Input Values: ");
            _val1 = Convert.ToInt32(Console.ReadLine());
            _val2 = Convert.ToInt32(Console.ReadLine());
        }
        public int DoSomething()
        {
            GetValues();
            return _val1 - _val2;
        }
    }

}
