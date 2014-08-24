using System;

namespace MovieRental
{
    public class Number
    {
        private readonly double number;

        public Number(int number)
        {
            this.number = number;
        }

        public Number(double number)
        {
            this.number = number;
        }

        public int GetIntValue()
        {
            int value = 0;
            Int32.TryParse(number.ToString(), out value);

            return value;
        }

        public double GetDoubleValue()
        {
            double value = 0;
            Double.TryParse(number.ToString(), out value);

            return value;
        }

        public static Number operator +(Number c1, Number c2) 
        {
            return new Number(c1.GetDoubleValue() + c2.GetDoubleValue());
        }

        public static Number operator -(Number c1, Number c2) 
        {
            return new Number(c1.GetDoubleValue() - c2.GetDoubleValue());
        }

        public static Number operator *(Number c1, Number c2) 
        {
            return new Number(c1.GetDoubleValue() * c2.GetDoubleValue());
        }

        public static bool operator ==(Number c1, Number c2) 
        {
            return c1.GetDoubleValue().Equals(c2.GetDoubleValue());
        }

        public static bool operator !=(Number c1, Number c2) 
        {
            return !c1.GetDoubleValue().Equals(c2.GetDoubleValue());
        }

        public override bool Equals(object obj)
        {
            try 
            {
                return (bool) (this == (Number) obj);
            }
            catch 
            {
                return false;
            }
        }

        public override int GetHashCode() 
        {
            return number.GetHashCode();
        }
    }
}

