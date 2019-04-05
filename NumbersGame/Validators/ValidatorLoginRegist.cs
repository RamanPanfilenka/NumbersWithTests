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

        public bool Validate(string value)
        {
            if (value.Length == 0 || value.Length < 4 || value.Length > 20)
            {
                Error = "Error. Not enaeble length of login. It's should be > 6 and < 20";
                return false;
            }
            var UserRepo = new UsersRepository();
            if (UserRepo.Get(value) != null)
            {
                Error = "Error. This login is already exist. Pls enter some different.";
                return false;
            }
            return true;
        }
    }
}
