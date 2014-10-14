using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    class Program
    {
        public static void Main()
        {

            //MoneyStruct m = new MoneyStruct();
            MoneyStruct m = new MoneyStruct(Currency.Euro, 200);
            MoneyStruct m1 = new MoneyStruct(Currency.Dollar, 200);

            double convert = MoneyStruct.Convert(Currency.Euro, Currency.Dollar, 200);
            Console.WriteLine(convert);

            MoneyStruct m3 = m + m1;
            Console.WriteLine("Currency is " + m3.Currency + " Amount " + m3.Amount);
            Console.ReadLine();

        }
    }
}
