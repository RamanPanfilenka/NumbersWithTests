using NumberGame.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumbersGame.Validators
{
    public class ValidatorPasswordRegist : IValidator<string>
    {
        public string Error { get; set; }

        public bool Validate(string value)
        {
            bool correct = true;
            char[] mass = {' ', '?', '|' };
            for (int i = 0; i < mass.Length; i++)
            {
                if (value.IndexOf(mass[i]) != -1)
                {
                    correct = false;
                    break;
                }
            }
            if (value.Length == 0 || value.Length < 6 || !correct || value.Length > 30)
            {
                Error = "Error. Not enaeble length. It's should be > 6, < 30 and not contain ?, |, and spaces";
                return false;
            }

            if ( value == "restore")
            {
                Error = "Error. You can't use this password. Pls change it.";
                return false;
            }
            return true;
        }
    }
}
