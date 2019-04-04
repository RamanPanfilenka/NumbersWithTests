using NumberGame.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumbersGame.Validators
{
    public class ValidatorEnterUser: IValidator<int> 
    {
        public string Error { get; set;}

        public bool Validate(int value)
        {
            if (value < 1 || value > 3)
            {
                Error = "Error. It's sholuld be 1 or 2 or 3";
                return false;
            }

            return true;
        }
    }
}
