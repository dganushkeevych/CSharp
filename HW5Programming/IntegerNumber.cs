using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RationalInteger
{
    public class IntegerNumber : INumber, IInputOutput
    {
        public int number { get; set; }
               
        public IntegerNumber(int Number = 0)
        {
            number = Number;
        }

        public INumber Adding(INumber number)
        {
            if (number.GetType() == typeof(IntegerNumber))
            {
                var num = number as IntegerNumber;
                return new IntegerNumber(this.number + num.number);
            }
            else if (number.GetType() == typeof(RationalNumber))
            {
                var num = number as RationalNumber;
                return new RationalNumber(this.number * num.denominator + num.numerator, num.denominator);
            }
            else
            {
                throw new ArgumentException("Error!");
            }
        }

        public INumber Substraction(INumber number)
        {
            if (number.GetType() == typeof(IntegerNumber))
            {
                var num = number as IntegerNumber;
                return new IntegerNumber(this.number - num.number);
            }
            else if (number.GetType() == typeof(RationalNumber))
            {
                var num = number as RationalNumber;
                var num1 = new RationalNumber(this.number * num.denominator, num.denominator);
                return num1.Substraction(num);
            }
            else
            {
                throw new ArgumentException("Error!");
            }
        }

        public INumber Division(INumber number)
        {
            if (number.GetType() == typeof(IntegerNumber))
            {
                var num = number as IntegerNumber;
                return new IntegerNumber(this.number / num.number);
            }
            else if (number.GetType() == typeof(RationalNumber))
            {
                var num = number as RationalNumber;
                var num1 = new RationalNumber(this.number, 1);
                return num1.Division(num);
            }
            else
            {
                throw new ArgumentException("Error!");
            }
        }

        public INumber Multiplication(INumber number)
        {
            if (number.GetType() == typeof(IntegerNumber))
            {
                var num = number as IntegerNumber;
                return new IntegerNumber(this.number * num.number);
            }
            else if (number.GetType() == typeof(RationalNumber))
            {
                var num = number as RationalNumber;
                var num1 = new RationalNumber(this.number, 1);
                return num1.Multiplication(num);
            }
            else
            {
                throw new ArgumentException("Error!");
            }
        }

        public override string ToString() => $"{number}";

        public void InputData(string line)
        {
            int num = Convert.ToInt32(line);
            this.number = num;
        }

        public void OutputData(StreamWriter streamWriter)
        {
            streamWriter.WriteLine(this);
        }
    }
}
