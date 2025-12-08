using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public record Transaction(decimal Amount, DateTime Date, string Notes);
}
