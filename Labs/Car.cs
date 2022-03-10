using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs
{
    public class Car
    {
        private readonly string _name = "Default name";
        private readonly int _ownerId;
        private readonly string _color = "Default color";

        public Car(int ownerId, string name, string color)
        {
            _ownerId = ownerId;
            _name = name;
            _color = color;
        }

        public override string ToString()
        {
            var properties = $"Owner Id - {_ownerId}, name - {_name} and color - {_color}";

            return properties;
        }
    }
}
