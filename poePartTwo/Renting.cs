//ST10085103
//PROG-POE-PART2
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace poePartTwo
{
    internal class Renting : Expenses
    {
        //CLASS FIELD
        public double RentalAmount { set; get; }


        //METHOD CALCULATES COST OF RENTING ACCOMODATION
        public override double calcAccomodation(double grossIncome)
        {
            double houseCost = grossIncome - RentalAmount;

            return houseCost;
        }
    }
}