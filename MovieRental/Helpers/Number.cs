﻿using System;

namespace MovieRental
{
    public class Number
    {
        private readonly double doubleNumber;
        private readonly int intNumber;
        private readonly bool isInt;

        public Number(int number)
        {
            this.intNumber = number;            
            this.doubleNumber = 0;
            this.isInt = true;
        }

        public Number(double number)
        {
            this.intNumber = 0;
            this.doubleNumber = number;
            this.isInt = false;
        }

        public int GetIntValue()
        {
            int value = 0;
            Int32.TryParse(intNumber.ToString(), out value);

            return value;
        }

        public double GetDoubleValue()
        {
            double value = 0;
            Double.TryParse(doubleNumber.ToString(), out value);

            return value;
        }

        static bool AreIntValues(Number c1, Number c2)
        {
            return c1.isInt && c2.isInt;
        }

        public static Number operator +(Number c1, Number c2)
        {
            if (AreIntValues(c1, c2))
            {
                return new Number(c1.GetIntValue() + c2.GetIntValue());
            }
            else
            {
                return new Number(c1.GetDoubleValue() + c2.GetDoubleValue());
            }
        }

        public static Number operator -(Number c1, Number c2) 
        {
            if (AreIntValues(c1, c2))
            {
                return new Number(c1.GetIntValue() - c2.GetIntValue());
            }
            else
            {
                return new Number(c1.GetDoubleValue() - c2.GetDoubleValue());
            }
        }

        public static Number operator *(Number c1, Number c2) 
        {
            if (AreIntValues(c1, c2))
            {
                return new Number(c1.GetIntValue() * c2.GetIntValue());
            }
            else
            {
                return new Number(c1.GetDoubleValue() * c2.GetDoubleValue());
            }
        }

        public static bool operator ==(Number c1, Number c2) 
        {
            if (AreIntValues(c1, c2))
            {
                return c1.GetIntValue().Equals(c2.GetIntValue());
            }
            else
            {
                return c1.GetDoubleValue().Equals(c2.GetDoubleValue());
            }
        }

        public static bool operator !=(Number c1, Number c2) 
        {
            if (AreIntValues(c1, c2))
            {
                return !c1.GetIntValue().Equals(c2.GetIntValue());
            }
            else
            {
                return !c1.GetDoubleValue().Equals(c2.GetDoubleValue());
            }
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
            if (isInt)
            {
                return intNumber.GetHashCode();
            }
            else
            {
                return doubleNumber.GetHashCode();
            }
        }

        public static bool operator >(Number c1, Number c2) 
        {
            if (AreIntValues(c1, c2))
            {
                return c1.GetIntValue() > c2.GetIntValue();
            }
            else
            {
                return c1.GetDoubleValue() > c2.GetDoubleValue();
            }
        }

        public static bool operator <(Number c1, Number c2) 
        {
            if (c1.isInt && c2.isInt)
            {
                return c1.GetIntValue() < c2.GetIntValue();
            }
            else
            {
                return c1.GetDoubleValue() < c2.GetDoubleValue();
            }
        }
    }
}

