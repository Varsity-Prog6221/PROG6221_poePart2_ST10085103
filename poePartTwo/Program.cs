//ST10085103
//PROG-POE-PART2
using System;
using System.Collections.Generic;
using System.Linq;


namespace poePartTwo
{
    internal class Program
    {
        //CREATED DELEGATE
        public delegate void MyDelegate(string msg);

        static void Main(string[] args)
        {
            //CLASS FIELDS
            double rentalCost = 0;
            double homeloanCost = 0;
            double vehicleCost = 0;
            double expenditures = 0;
            double totalExpense = 0;
            List<double> expenseArray = new List<double>();

            //INPUT FOR GROSS-INCOME & TAX
            Console.WriteLine("Enter Gross monthly income (before deductions)");
            double grossIncome = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter Estimated monthly tax deducted");
            double tax = Convert.ToDouble(Console.ReadLine());

            //COLLECT EXPENDITURE INPUT & ADD TO ARRAY
            Console.WriteLine("Enter monthly expenditures for the following: ");
            Console.WriteLine("Groceries: ");
            expenseArray.Add(Convert.ToDouble(Console.ReadLine()));
            Console.WriteLine("Water and Lights: ");
            expenseArray.Add(Convert.ToDouble(Console.ReadLine()));
            Console.WriteLine("Travel Costs (including petrol): ");
            expenseArray.Add(Convert.ToDouble(Console.ReadLine()));
            Console.WriteLine("Cell Phone and Telephone: ");
            expenseArray.Add(Convert.ToDouble(Console.ReadLine()));
            Console.WriteLine("Other Expenses: ");
            expenseArray.Add(Convert.ToDouble(Console.ReadLine()));


            //ADDS UP EXPENDITURES
            for (int i = 0; i < expenseArray.Count(); i++)
            {
                expenditures += expenseArray[i];
            }


            //DECISION: RENT | BUY?
            Console.WriteLine("\nDo you want to rent or buy property? Press 'r' to rent, any other key to buy.");
            String rentOrBuy = Console.ReadLine();
            //IF RENTING
            if (rentOrBuy == "r")
            {
                Renting rent = new Renting();
                Console.WriteLine("Enter monthly rental amount: ");
                rent.RentalAmount = Convert.ToDouble(Console.ReadLine());
                //DISPLAYS AVAILABLE MONEY & RENTAL-COST
                rentalCost = rent.RentalAmount;
                double availableMoney = grossIncome - (tax + expenditures + rentalCost);
                Console.WriteLine("\nThe Available Monthly Money is: R" + availableMoney);
            }
            //IF BUYING (HOMELOAN)
            else
            {
                HomeLoan homeloan = new HomeLoan();
                Console.WriteLine("Enter Purchase Price: ");
                homeloan.PurchasePrice = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Enter Total Deposit: ");
                homeloan.TotalDeposit = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Enter Interest Rate (percentage): ");
                homeloan.InterestRate = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Enter Number of Months (between 240 and 360): ");
                homeloan.NumMonths = Convert.ToInt32(Console.ReadLine());
                //DISPLAYS AVAILABLE MONEY & HOMELOAN REPAYMENT
                homeloanCost = homeloan.getHomeLoanRepayment();
                double availableMoney = grossIncome - (tax + expenditures + homeloanCost);
                //Console.WriteLine("\nThe homeloan cost is: R" + homeloan.calcAccomodation(grossIncome));
                Console.Write("\nThe Homeloan Repayment is: R" + homeloanCost);
                Console.WriteLine("\nThe Available Monthly Money is: R" + availableMoney);

                //ASSESS CHANCE OF HOMELOAN APPROVAL
                if (homeloan.getHomeLoanRepayment() > (grossIncome * 0.33))
                {
                    Console.WriteLine("\nApproval of Homeloan is unlikely.");
                }
            }


            //DECISION: BUY VEHICLE?
            Console.WriteLine("\nDo you want to buy a car? Press 'y' for yes, any other key for no");
            string toBuyCar = Console.ReadLine();

            //IF BUY VEHICLE
            if (toBuyCar == "y")
            {
                CarPurchase car = new CarPurchase();
                Console.WriteLine("Enter Car Model and Make: ");
                car.CarModel = Console.ReadLine();
                Console.WriteLine("Enter Purchase Price: ");
                car.CarPrice = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Enter Total Deposit: ");
                car.CarDeposit = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Enter Interest Rate (Percentage): ");
                car.CarInterestRate = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Enter Estimated Insurance Premium: ");
                car.CarPremium = Convert.ToDouble(Console.ReadLine());

                //CAR PURCHASE EXPENSE ADDED TO EXPENSE ARRAY
                vehicleCost = car.getCarMonthlyCost();
                Console.WriteLine("\nThe monthly cost of car purchase is: R" + vehicleCost);
            }


            //NOTIFY IF COST EXCEED 75% OF INCOME
            totalExpense = tax + expenditures + rentalCost + homeloanCost + vehicleCost;
            if (vehicleCost > 0 && totalExpense > (grossIncome * 0.75))
            {
                String msg = "\nThe cost of buying the car exceeds 75% of your income";

                //INVOKE DELEGATE
                MyDelegate d = new MyDelegate(Display);
                d.Invoke(msg);
            }


            //DISPLAY TOTAL EXPENSES
            Console.WriteLine("\nYour Total Expense is: R" + totalExpense);


            //ADDING RENT, HOMELOAN & VEHICLE COSTS TO ARRAY
            expenseArray.Add(tax);
            expenseArray.Add(rentalCost);
            expenseArray.Add(homeloanCost);
            expenseArray.Add(vehicleCost);


            //SORTING EXPENSE ARRAY
            expenseArray.Sort((a, b) => b.CompareTo(a));
            Console.WriteLine("\nAll Expenses in Descending Order: ");
            for (int i = 0; i < expenseArray.Count(); i++)
            {
                Console.Write("R" + expenseArray[i] + ", ");
            }
            Console.WriteLine();
        }

        //METHOD INVOKED BY DELEGATE
        static void Display(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
