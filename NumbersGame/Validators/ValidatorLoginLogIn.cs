using Dal.Repositorys;
using NumberGame.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumbersGame.Validators
{
    public class ValidatorLoginLogIn : IValidator<string>
    {
        public string Error { get; set; }

        public bool Validate(string value)
        {
            var UserRepo = new UsersRepository();
            if (value != "exit")
            {
                if (UserRepo.Get(value) == null || String.IsNullOrEmpty(value))
                {
                    Error = "Error. This login is not exist. Pls enter some different.";
                    return false;
                }
            }
            return true;
        }
    }
}
