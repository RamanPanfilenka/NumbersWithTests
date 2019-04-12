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
    public class ValidatorLoginRegist : IValidator<string>
    {
        public string Error { get; set; }

        public bool Validate(string value, IUsersRepository UserRepo = null)
        {
            bool correct = true;
            char[] mass = { ' ', '?', '|' };

            for (int i = 0; i < mass.Length; i++)
            {
                if (value.IndexOf(mass[i]) != -1)
                {
                    correct = false;
                    break;
                }
            }

            if (value.Length == 0 || value.Length < 4 || value.Length > 20 || !correct)
            {
                Error = "Error. Not enaeble login. It's should be > 6 and < 20 and not contain spaces, ? and |";
                return false;
            }
            if (UserRepo.Get(value) != null)
            {
                Error = "Error. This login is already exist. Pls enter some different.";
                return false;
            }
            return true;
        }
    }
}
