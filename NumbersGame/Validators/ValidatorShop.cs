using NumberGame.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumbersGame.Validators
{
    public class ValidatorShop : IValidator<string>
    {
        public string Error { get; set; }

        public bool Validate(string value)
        {
            int number;
            if (int.TryParse(value,out number))
            {
                if (number < 1 && number > 3)
                {
                    Error = "Error. It's should be between 1 and 3 or exit";
                    return false;
                }

                return false;
            }

            if (value == "exit")
            {
                return true;
            }

            return false;
        }
    }
}
