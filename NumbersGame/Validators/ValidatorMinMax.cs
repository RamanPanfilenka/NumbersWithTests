using Dal.IRepository;
using Dal.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGame.Validators
{
    public class ValidatorMinMax : IValidator<int>
    {
        private int _min;
        private int _max;

        public string Error { get; set; }

        public ValidatorMinMax(int min, int max)
        {
            _min = min;
            _max = max;
        }

        public bool Validate(int value, IUsersRepository users = null)
        {
            if (value > _max || value < _min)
            {
                Error = $"Error. Your value should be between {_min} and {_max}. Enter again";
                return false;
            }

            return true;
        }
    }
}
