using System;
using System.Collections.Generic;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora
{
    internal class Calc
    {
        private List<double> numbers = new List<double>();
        private List<double> actualNumbers = new List<double>();

        public void addNumber(double number)
        {
            numbers.Add(number);
        }

        public double[] getNumbers()
        {
            return numbers.ToArray();
        }
        public int getCantNumbers()
        {
            return numbers.Count;
        }

        public double power(double number, int to)
        {
            if (to == 0)
            {
                return 1;
            }
            return number * power(number, to - 1);
        }
        public double makeNumber()
        {
            double number = 0.0;
            for (int i = 0; i < numbers.Count; i++)
            {
                // 1, 2, 3 
                // 0, 1, 2
                // 123
                // cdu
                // 100 * 0 + 10 * 1 + 1 * 2
                
                // 10 ** 2 = 100
                // 10 ** 1 = 10
                // 10 ** 0 = 1
                number = number + numbers[i] * power(10, numbers.Count - (i + 1));
            }
            actualNumbers.Add(number);
            numbers.Clear();
            return number;
        }
        public double operate(string op)
        {
            double first = 0.0, second = 0.0;
            if (actualNumbers.Count == 1)
            {
                first = actualNumbers[0];
                if (numbers.Count == 1)
                {
                    second = numbers[0];
                }
            }
            else if (actualNumbers.Count > 1)
            {
                first = actualNumbers[0];
                second = actualNumbers[1];
            }

            actualNumbers.Clear();

            switch (op)
            {
                case "+":
                    return first + second;
                case "-":
                    return first - second;
                case "*":
                    return first * second;
                case "/":
                    return first / second;
                default:
                    return 0.0;
            }
        }
    }
}
