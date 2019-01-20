using System;

namespace AcceptanceTest
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
