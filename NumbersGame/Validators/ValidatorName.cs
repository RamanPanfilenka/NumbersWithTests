using NumberGame.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumbersGame.Validators
{
    public class ValidatorName : IValidator<string>
    {
        public string Error { get; set; }

        public bool Validate(string value)
        {
            int count = 0;
            for (int i = 0; i < value.Length; i++)
            {
                if (Char.IsLetter(value[i]) || value[i] == '-')
                    count++;
            }
            if (count != value.Length)
            {
                Error = "Error. Type real name! Enter again";
                return false;
            }

            return true;
        }
    }
}
