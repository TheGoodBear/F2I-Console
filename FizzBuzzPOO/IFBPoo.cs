using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzzPOO
{
    internal interface IFBPoo
    {

        bool IsDivisibleBy3(object Number);

        bool IsDivisibleBy5(int Number);

        string GetNumberResult(object Number);

    }
}
