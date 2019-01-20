using fit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class MyAcceptanceTests : ColumnFixture
    {
        public string FirstString;
        public string SecondString;
        public string Concatenate()
        {
            return FirstString + " " + SecondString;
        }
    }
}
