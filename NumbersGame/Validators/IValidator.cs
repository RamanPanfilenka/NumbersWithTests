using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGame.Validators
{
    public interface IValidator<T>
    {
        string Error { get; set; }

        bool Validate(T value);

    }
}
