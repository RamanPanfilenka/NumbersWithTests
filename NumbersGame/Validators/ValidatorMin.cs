using Dal.IRepository;
using Dal.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGame.Validators
{
    public class ValidatorMin : IValidator<int>
    {
        private int _min { get; set; }
        public string Error { get; set; }

        public ValidatorMin(int min)
        {
            _min = min;
        }

        public bool Validate(int value, IUsersRepository users = null)
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
