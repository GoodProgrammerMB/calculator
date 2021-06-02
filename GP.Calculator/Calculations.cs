using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GP.Calculator.Interfaces;

namespace GP.Calculator
{
    public class Calculations : ICalculations
    {

        public int GetFirstArgument(IEnumerable<string> lines)
        {
            //Regex.Replace(input, "world", "csharp", RegexOptions.IgnoreCase);
            var firstNumber = lines.Last().ToLower().Contains("apply") ? lines.Last().Trim().Remove(0,5) : throw new Exception("Incorect data");
            return int.Parse(firstNumber);
        }

        public decimal Calculate(string step, decimal previous)
        {
            var items = step.Split(' ');
            if (items is {Length: < 2})
            {
                throw new Exception("Wrong params");
            }

            return items[0] switch
            {
                "add" => Add(previous, decimal.Parse(items[1])),
                "multiply" => Multiplication(previous, decimal.Parse(items[1])),
                "divide" => Division(previous, decimal.Parse(items[1])),
                "subtract" => Subtraction(previous, decimal.Parse(items[1])),
                _ => 0,
            };
        }

        private decimal Add(decimal a, decimal b)
        {
            return a + b;
        }
        private decimal Division(decimal a, decimal b)
        {
            return a / b;
        }

        private decimal Multiplication(decimal a, decimal b)
        {
            return a * b;
        }

        private decimal Subtraction(decimal a, decimal b)
        {
            return a - b;
        }
    }
}
