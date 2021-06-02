using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.Calculator.Interfaces
{
    public interface ICalculations
    {
        int GetFirstArgument(IEnumerable<string> lines);
        decimal Calculate(string step, decimal previous);
    }
}
