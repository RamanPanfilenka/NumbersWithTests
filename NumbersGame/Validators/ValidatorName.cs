using Dal.IRepository;
using Dal.Repositorys;
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

        public bool Validate(string value, IUsersRepository users = null)
        {
            int count = 0;
            if (value.Length > 30)
            {
                Error = "Name should be < 30. Sorry";
                return false;
            }
            for (int i = 0; i < value.Length; i++)
            {
                if (Char.IsLetter(value[i]) || value[i] == '-')
                    count++;
            }
            if (count != value.Length || value.Length == 0)
            {
                Error = "Error. Type real name! Enter again";
                return false;
            }

            return true;
        }
    }
}

