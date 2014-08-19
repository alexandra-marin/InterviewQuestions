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

        public double GetValue()
        {
            double value = 0;
            Double.TryParse(number.ToString(), out value);

            return value;
        }

        public static Number operator +(Number c1, Number c2) 
        {
            return new Number(c1.GetValue() + c2.GetValue());
        }

        public static Number operator -(Number c1, Number c2) 
        {
            return new Number(c1.GetValue() - c2.GetValue());
        }

        public static Number operator *(Number c1, Number c2) 
        {
            return new Number(c1.GetValue() * c2.GetValue());
        }

        public static bool operator ==(Number c1, Number c2) 
        {
            return c1.GetValue().Equals(c2.GetValue());
        }

        public static bool operator !=(Number c1, Number c2) 
        {
            return !c1.GetValue().Equals(c2.GetValue());
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

