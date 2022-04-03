using System;

namespace NLayerApp.BLL.BusinessModels
{
    public class Discount
    {
        public Discount(decimal val)
        {
            _value = val;
        }
        private decimal _value = 0;
        public decimal Value { get { return _value; } }
        public decimal GetDiscountedPrice(decimal sum)
        {
            if (DateTime.Now.Day == 1)
                return sum - sum * _value;
            return sum;
        }
    }
}