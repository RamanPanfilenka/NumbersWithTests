using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGame.Validators
{
    class ValidatorMin : IValidator<int>
    {
        private int _min { get; set; }
        public string Error { get; set; }

        public ValidatorMin(int min)
        {
            _min = min;
        }

        public bool Validate(int value)
        {
            if (value <= _min)
            {
                Error = $"Error. Value should be greater than {_min}. Enter again.";
                return false;
            }

            return true;
        }
    }
}
