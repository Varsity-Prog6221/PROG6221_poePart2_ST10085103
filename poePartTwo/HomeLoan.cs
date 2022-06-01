//ST10085103
//PROG-POE-PART2
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace poePartTwo
{
    internal class HomeLoan : Expenses
    {
        //CLASS FIELDS
        public double PurchasePrice { set;  get; }
        public double TotalDeposit { set; get; }
        public double InterestRate { set; get; }
        public int NumMonths { set; get; }


        //METHOD CALCULATES HOMELOAN REPAYMENT
        public double getHomeLoanRepayment()
        {
            //HOMELOAN REPAYMENT CALCULATION FOMULAR
            double repayment = ((PurchasePrice - TotalDeposit) * (1 + (InterestRate / (double)100) * ((double)NumMonths / (double)12))) / (double)NumMonths;         

            return repayment;
        }


        //METHOD CALCULATES HOMELOAN ACCOMODATION COST
        public override double calcAccomodation(double grossIncome)
        {
            double houseCost = grossIncome - getHomeLoanRepayment();

            return houseCost;
        }
    }
}
