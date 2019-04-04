using NumberGame.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumbersGame
{
   public static class ReadInteger
    {
        public static int FromConsole(IValidator<int> validator = null)
        {
            int number;
            var line = Console.ReadLine();

            do
            {

                if (validator?.Error != null)
                {
                    Console.WriteLine(validator.Error);
                    line = Console.ReadLine();
                }

                while (!int.TryParse(line, out number))
                {
                    Console.WriteLine("Error. It's not a number. Pls enter again");
                    line = Console.ReadLine();
                }
            } while (!validator?.Validate(number) ?? false);
            if (validator != null)
                validator.Error = null;
            return number;
        }

        
    }
}
