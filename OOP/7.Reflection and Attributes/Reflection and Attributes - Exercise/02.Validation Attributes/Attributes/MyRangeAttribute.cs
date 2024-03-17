using System;

namespace ValidationAttributes.Attributes
{
    public class MyRangeAttribute : MyValidationAttribute
    {   
        private readonly int _minValue;
        private readonly int _maxValue;

        public MyRangeAttribute(int minValue, int maxValue)
        {
            _minValue = minValue;
            _maxValue = maxValue;
        }

        public override bool IsValid(object obj)
        {   
            //Връщаме резултата само ако е в диапазона на int.MaxValue и int.MinValue
            return (int)obj >= _minValue && (int)obj <= _maxValue;
        }
    }
}
