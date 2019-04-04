using NumberGame.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumbersGame.Readers
{
    class ReadString
    {
        public static string FromConsole(IValidator<string> validator = null)
        {
            var line = Console.ReadLine();
            while (!validator?.Validate(line) ?? false)
            {
                Console.WriteLine(validator.Error);
                line = Console.ReadLine();
            }
            return line;
        }
    }
}