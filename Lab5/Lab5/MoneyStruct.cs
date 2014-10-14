using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    public enum Currency
    {
        Euro, Dollar, Yen
    }
    struct MoneyStruct
    {
        /*Implement a Money structure which stores an amount of money and the currency unit for that amount. 
             * Currency units should be euro or US dollar or yen. Use auto-implemented properties. 
             * Add a non-default constructor allowing the amount and the currency unit to be specified at the time of 
             * construction of an object.*/
        public double Amount{ get; set; }

        public Currency Currency { get; set; }

        public const double EuroDollarRate = 1.26574; //€1 = xxxx dollar
        public const double EuroYenRate = 135.581; //€1 = xxxx Yen
        public const double DollarYenRate = 107.117; // $1 = xxxx Yen 

        public MoneyStruct (Currency cur, double amount)
            : this()
        {
            Currency = cur;
            Amount = amount;
        }

        //Implement a method in the structure which allows the currency amount to be converted into an 
         //   amount in a different currency and returned. 
          //  Store the various conversion rates to be used in the conversion as constants in the structure.

        public static double Convert(Currency from, Currency to , double a)
        {
            double ConvertedAmount = 0;

            if (from == to)
            {
                return a; //if currenies are the same
            }
            else if(a <=0 )
            {
                throw new ArgumentException("Cnnot convert negative amounts");
            }
            else
            {
                if ((from == Currency.Dollar) && (to == Currency.Euro))  //Dollar to Euro
                {
                    ConvertedAmount = a / EuroDollarRate;
                }
                else if ((from == Currency.Dollar) && (to == Currency.Yen)) // Doller to Yen
                {
                    ConvertedAmount = a * DollarYenRate;
                }
                else if ((from == Currency.Euro) && (to == Currency.Dollar)) //Euro to Dollar
                {
                    ConvertedAmount = a * EuroDollarRate;
                }
                else if ((from == Currency.Euro) && (to == Currency.Yen)) //Euro to Yen
                {
                    ConvertedAmount = a * EuroYenRate;
                }
                else if ((from == Currency.Yen) && (to == Currency.Dollar)) //Yen to Dollar
                {
                    ConvertedAmount = a / DollarYenRate;
                }
                else if ((from == Currency.Yen) && (to == Currency.Euro)) //Yen to Euro
                {
                    ConvertedAmount = a / EuroYenRate;
                }
                else
                {
                    throw new ArgumentException("An Error Occured, Cannot convert that Currency "
                        + from + " or Amount " + a);
                }
                return ConvertedAmount;
            }
        }
        /*Implement a method which allows 2 Money objects to be added together. 
         * The first Money object determines the currency unit for the result e.g. euro + dollar = euro. 
         * Convert currencies if necessary in this method.*/

        static public MoneyStruct operator +( MoneyStruct lhs, MoneyStruct rhs) 
        {
           
            return new MoneyStruct(lhs.Currency, lhs.Amount +=  Convert(lhs.Currency, rhs.Currency, rhs.Amount));
        }



    }
}
